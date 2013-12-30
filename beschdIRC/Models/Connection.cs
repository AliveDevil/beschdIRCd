using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace beschdIRC.Models
{
	public class Connection
	{
		public string Nick { get; set; }
		public string Servername { get; set; }
		public string Realname { get; set; }
		public string Hostname { get; set; }
		public string Pass { get; set; }
		public bool Away { get; set; }
		public bool Registered { get; set; }
		public IPAddress IPAddress
		{
			get
			{
				return ((IPEndPoint)client.Client.RemoteEndPoint).Address;
			}
		}

		private Server server;
		private TcpClient client;
		private NetworkStream netStream;
		private StreamReader reader;
		private StreamWriter writer;

		private DateTime lastPingTime;
		private Timer pingTimer;

		private CancellationTokenSource cancelSource;

		public Connection(Server server, TcpClient client)
		{
			this.server = server;
			this.client = client;
			this.netStream = this.client.GetStream();

			this.reader = new StreamReader(this.netStream);
			this.writer = new StreamWriter(this.netStream);

			this.cancelSource = new CancellationTokenSource();

			this.readAsync().Start();

			this.Ping();
		}

		// fixed for nikeee
		private Task readAsync()
		{
			return new Task(reading);
		}
		private void reading()
		{
			while (client.Connected && !cancelSource.IsCancellationRequested)
			{
				if (lastPingTime - DateTime.Now < TimeSpan.FromMinutes(3))
				{
					if (netStream.DataAvailable)
					{
						server.ExecuteAction(this, reader.ReadLine());
					}
					else
					{
						Thread.Sleep(250);
					}
				}
				else
				{
					Disconnect("Timed out");
				}
			}
			Disconnect();
		}
		private void timerCallback(object state)
		{
			server.LogConnection(this, "sent ping");
			Send("PING");
		}

		public void Ping()
		{
			this.pingTimer = new Timer(timerCallback, null, TimeSpan.FromMinutes(2.5), TimeSpan.FromMilliseconds(-1));
			lastPingTime = DateTime.Now;
		}
		public void Notice(string command, string message)
		{
			Send(string.Format(":{0} NOTICE {1} :{2}", server.Settings.ServerAddress, command, message));
		}
		public void Send(string message)
		{
			writer.WriteLine(message);
			writer.Flush();
		}
		public void Disconnect(bool trace = true)
		{
			if (trace)
			{
				Trace.TraceInformation("Client disconnected");
			}
			this.cancelSource.Cancel();
			this.reader.Dispose();
			this.writer.Dispose();
			this.netStream.Dispose();
			this.client.Close();
			this.server.Disconnect(this);
		}
		public void Disconnect(string reason)
		{
			Disconnect(false);
		}
	}
}
