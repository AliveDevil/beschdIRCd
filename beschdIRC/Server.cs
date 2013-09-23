using beschdIRC.Migrations;
using beschdIRC.Models;
using beschdIRC.Models.Database;
using beschdIRC.Settings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace beschdIRC {
	public class Server {
		#region Error-Messages
		Dictionary<ErrorCodes, string> errorMessages = new Dictionary<ErrorCodes, string>
		{
			{ ErrorCodes.NOSUCHNICK, "<nickname> :No such nick/channel" },
			{ ErrorCodes.NOSUCHSERVER, "<servername> :No such server" },
			{ ErrorCodes.NOSUCHCHANNEL, "<channelname> :No such channel" },
			{ ErrorCodes.CANNOTSENDTOCHAN, "<channelname> :Cannot send to channel" },
			{ ErrorCodes.TOOMANYCHANNELS, "<channelname> :You have joined too many channels" },
			{ ErrorCodes.WASNOSUCHNICK, "<nickname> :There was no such nickname" },
			{ ErrorCodes.TOOMANYTARGETS, "<target> :Duplicate recipients. No message delivered" },
			{ ErrorCodes.NOORIGIN, ":No origin specified" },
			{ ErrorCodes.NORECIPIENT, ":No recipient given (<command>)" },
			{ ErrorCodes.NOTEXTTOSEND, ":No text to send" },
			{ ErrorCodes.NOTOPLEVEL, "<mask> :No toplevel domain specified" },
			{ ErrorCodes.WILDTOPLEVEL, "<mask> :Wildcard in toplevel domain" },
			{ ErrorCodes.UNKNOWNCOMMAND, "<command> :Unknown command" },
			{ ErrorCodes.NOMOTD, ":MOTD File is missing" },
			{ ErrorCodes.NOADMININFO, "<server> :No administrative info available" },
			{ ErrorCodes.FILEERROR, ":File error doing <fileop> on <file>" },
			{ ErrorCodes.NONICKNAMEGIVEN, ":No nickname given" },
			{ ErrorCodes.ERRONEUSNICKNAME, "<nickname> :Erroneus nickname" },
			{ ErrorCodes.NICKNAMEINUSE, "<nickname> :Nickname is already in use" },
			{ ErrorCodes.NICKCOLLISION, "<nickname> :Nickname collision KILL" },
			{ ErrorCodes.USERNOTINCHANNEL, "<nickname> <channel> :They aren't on that channel" },
			{ ErrorCodes.NOTONCHANNEL, "<channel> :You're not on that channel" },
			{ ErrorCodes.USERONCHANNEL, "<nickname> <channel> :is already on channel" },
			{ ErrorCodes.NOLOGIN, "<nickname> :User not logged in" },
			{ ErrorCodes.SUMMONDISABLED, ":SUMMON has been disabled" },
			{ ErrorCodes.USERSDISABLED, ":USERS has been disabled" },
			{ ErrorCodes.NOTREGISTERED, ":You have not registered" },
			{ ErrorCodes.NEEDMOREPARAMS, "<command> :Not enough parameters" },
			{ ErrorCodes.ALREADYREGISTRED, ":You may not reregister" },
			{ ErrorCodes.NOPERMFORHOST, ":Your host isn't among the privileged" },
			{ ErrorCodes.PASSWDMISMATCH, ":Password incorret" },
			{ ErrorCodes.YOUREBANNEDCREEP, ":You are banned from this server" },
			{ ErrorCodes.KEYSET, "<channel> :Channel key already set" },
			{ ErrorCodes.CHANNELISFULL, "<channel> :Cannot join channel (+l)" },
			{ ErrorCodes.UNKNOWNMODE, "<char> :is unknown mode char to me" },
			{ ErrorCodes.INVITEONLYCHAN, "<channel> :Cannot join channel (+i)" },
			{ ErrorCodes.BANNEDFROMCHAN, "<channel> :Cannot join channel (+b)" },
			{ ErrorCodes.BADCHANNELKEY, "<channel> :Cannot join channel (+k)" },
			{ ErrorCodes.NOPRIVILEGES, ":Permission Denied- You're not an IRC operator" },
			{ ErrorCodes.CHANOPRIVSNEEDED, "<channel> :You're not channel operator" },
			{ ErrorCodes.CANTKILLSERVER, ":You can't kill a server" },
			{ ErrorCodes.NOOPERHOST, ":No O-lines for your host" },
			{ ErrorCodes.UMODEUNKNOWNFLAG, ":Unknown MODE flag" },
			{ ErrorCodes.USERSDONTMATCH, ":Cant change mode for other users" },
		};
		#endregion
		#region Reply Messages
		Dictionary<ReplyCodes, string> replyMessages = new Dictionary<ReplyCodes, string> {

		};
		#endregion

		public IRCSettings Settings;

		List<Connection> connections;
		TcpListener listener;

		public void Initialize() {
			LogAction("loading", "settings", loadSettings);
			LogAction("loading", "database", initDatabase);
		}
		public void Run() {
			LogAction("initializing", "Network Interfaces", initNetwork);
		}
		public void LogConnection(Connection connection, string message) {
			Trace.TraceInformation(string.Format("{0} {1}", string.IsNullOrWhiteSpace(connection.Nick) ? connection.IPAddress.ToString() : connection.Nick, message));
		}
		public void LogAction(string prefix, string name, Action action) {
			Trace.TraceInformation("{0} {1}", prefix, name);
			action();
			Trace.TraceInformation("done: {0} {1}", prefix, name);
		}
		public void Disconnect(Connection connection) {
			connections.Remove(connection);
		}
		public void Error(Connection connection, ErrorCodes errorCode, Dictionary<string, string> resolve) {
			string text = errorMessages[errorCode];
			foreach (KeyValuePair<string, string> item in resolve)
				text = text.Replace("<" + item.Key + ">", item.Value);
			connection.Send(string.Format("ERROR {0}", text));
		}
		public void ExecuteAction(Connection connection, string line) {
			string[] command = line.Split(' ');
			switch (command[0].ToLowerInvariant()) {
				case "pass":
					passConnection(connection, command.Skip(1).ToArray());
					break;
				case "nick":
					nickConnection(connection, command.Skip(1).ToArray());
					break;
				case "pong":
					pongConnection(connection, command.Skip(1).ToArray());
					break;

				case "quit":
					quitConnection(connection, command.Skip(1).ToArray());
					break;

				default:
					Trace.TraceWarning(line);
					break;
			}
			if (command[0].StartsWith(":")) {
				if (connection.Nick.ToLowerInvariant() == command[0].Substring(1).ToLowerInvariant()) {
					ExecuteAction(connection, string.Join(" ", command.Skip(1)));
				}
			}
		}

		public bool HasNick(string nick) {
			return connections.Any(item => item.Nick != null && item.Nick.ToLowerInvariant() == nick.ToLowerInvariant());
		}

		/// <summary>
		/// Sets the connection password of the specified connection.
		/// </summary>
		/// <param name="connection">The password.</param>
		/// <param name="args">Should be {"pass"}</param>
		/// <exception cref="ErrorCodes.NeedMoreParams" />
		/// <exception cref="ErrorCodes.AlreadyRegistered" />
		/// <remarks>
		/// <para>Issued by /PASS &lt;password&gt;</para>
		/// </remarks>
		private void passConnection(Connection connection, params string[] args) {
			if (args.Length > 0) {
				if (!connection.Registered) {
					LogConnection(connection, "set password");
					connection.Pass = args[0];
				} else {
					Error(connection, ErrorCodes.ALREADYREGISTRED, new Dictionary<string, string>());
				}
			} else {
				Error(connection, ErrorCodes.NEEDMOREPARAMS, new Dictionary<string, string> { { "command", "PASS" } });
			}
		}
		/// <summary>
		/// Sets the nick of the specified connection.
		/// </summary>
		/// <param name="connection">Connection the nick should be changed</param>
		/// <param name="args">should be at least {"nick"}</param>
		/// <exception cref="ErrorCodes.NicknameInUse" />
		/// <exception cref="ErrorCodes.NeedMoreParams" />
		/// <remarks>
		/// <para>Issued by /NICK &lt;nickname&gt;</para>
		/// </remarks>
		private void nickConnection(Connection connection, params string[] args) {
			if (args.Length > 0) {
				if (!HasNick(args[0])) {
					LogConnection(connection, "set nick to " + args[0]);
					connection.Nick = args[0];
				} else {
					Error(connection, ErrorCodes.NICKNAMEINUSE, new Dictionary<string, string> { { "nickname", args[0] } });
				}
			} else {
				Error(connection, ErrorCodes.NEEDMOREPARAMS, new Dictionary<string, string> { { "command", "NICK" } });
			}
		}
		/// <summary>
		/// Resets ping timer.
		/// </summary>
		/// <param name="connection">Pinged-Connection</param>
		/// <param name="args">should be {}</param>
		/// <exception cref="ErrorCodes.NoOrigin" />
		/// <exception cref="ErrorCodes.NoSuchServer" />
		/// <remarks>
		/// Issued by /PONG
		/// </remarks>
		private void pongConnection(Connection connection, params string[] args) {
			LogConnection(connection, "is alive");
			connection.Ping();
		}
		/// <summary>
		/// Quits the server.
		/// </summary>
		/// <param name="connection">Losing connection.</param>
		/// <param name="args">can be {"quit message"}</param>
		/// <remarks>
		/// Issued by QUIT &lt;QuitMessage&gt;
		/// </remarks>
		private void quitConnection(Connection connection, params string[] args) {
			if (args.Length > 0) {
				connection.Disconnect(string.Join(" ", args));
			} else {
				connection.Disconnect();
			}
		}
		/// <summary>
		/// Toggles away-state of connection
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="args"></param>
		private void awayConnection(Connection connection, params string[] args) {
			if (args.Length > 0)
				connection.Away = true;
			else
				connection.Away = false;
		}


		private void initNetwork() {
			connections = new List<Connection>();
			listener = new TcpListener(IPAddress.Parse(Settings.Address), Settings.Port);
			listener.Start();
			listener.BeginAcceptTcpClient(acceptTcp, null);
		}
		private void acceptTcp(IAsyncResult result) {
			TcpClient client = listener.EndAcceptTcpClient(result);
			Trace.TraceInformation("New Connection of IP {0}", client.Client.RemoteEndPoint);
			connections.Add(new Connection(this, client));
			listener.BeginAcceptTcpClient(acceptTcp, null);
		}
		private void initDatabase() {
			using (DatabaseContext database = new DatabaseContext()) {
				MigrateDatabaseToLatestVersion<DatabaseContext, Configuration> migrate = new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>();
				Database.SetInitializer<DatabaseContext>(migrate);
				migrate.InitializeDatabase(database);
			}
		}
		private void loadSettings() {
			Settings = new IRCSettings();
			Settings.Load();
		}
	}
}
