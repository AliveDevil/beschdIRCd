using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beschdIRC.Tracing
{
	public class ConsoleTraceListener : TextWriterTraceListener
	{
		public ConsoleTraceListener()
			: base(Console.Out)
		{
		}
		private string format(TraceEventType eventType, string message, params object[] args)
		{
			return string.Format("{0:dd.MM.yyyy} {0:HH:mm:ss} {1}: {2}", DateTime.Now, eventType, string.Format(message, args));
		}
		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id)
		{
			WriteLine(this.format(eventType, "{0}", ""));
		}
		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
		{
			WriteLine(this.format(eventType, format, args));
		}
		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
		{
			WriteLine(this.format(eventType, "{0}", message));
		}
	}
}
