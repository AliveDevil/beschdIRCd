using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace beschdIRC
{
	class Program
	{
		internal static void Main(string[] args)
		{
			Server server = new Server();
			server.LogAction("initializing", "server", server.Initialize);
			server.Run();
			Application.Run();
		}
	}
}
