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

namespace beschdIRC
{
	public class Server
	{
		#region Error-Messages
		Dictionary<ErrorCodes, string> errorMessages = new Dictionary<ErrorCodes, string> {
			{ErrorCodes.NOSUCHNICK, "<nickname> :No such nick/channel"},
			{ErrorCodes.NOSUCHSERVER, "<servername> :No such server"},
			{ErrorCodes.NOSUCHCHANNEL, "<channelname> :No such channel"},
			{ErrorCodes.CANNOTSENDTOCHAN, "<channelname> :Cannot send to channel"},
			{ErrorCodes.TOOMANYCHANNELS, "<channelname> :You have joined too many channels"},
			{ErrorCodes.WASNOSUCHNICK, "<nickname> :There was no such nickname"},
			{ErrorCodes.TOOMANYTARGETS, "<target> :Duplicate recipients. No message delivered"},
			{ErrorCodes.NOORIGIN, ":No origin specified"},
			{ErrorCodes.NORECIPIENT, ":No recipient given (<command>)"},
			{ErrorCodes.NOTEXTTOSEND, ":No text to send"},
			{ErrorCodes.NOTOPLEVEL, "<mask> :No toplevel domain specified"},
			{ErrorCodes.WILDTOPLEVEL, "<mask> :Wildcard in toplevel domain"},
			{ErrorCodes.UNKNOWNCOMMAND, "<command> :Unknown command"},
			{ErrorCodes.NOMOTD, ":MOTD File is missing"},
			{ErrorCodes.NOADMININFO, "<servername> :No administrative info available"},
			{ErrorCodes.FILEERROR, ":File error doing <file op> on <file>"},
			{ErrorCodes.NONICKNAMEGIVEN, ":No nickname given"},
			{ErrorCodes.ERRONEUSNICKNAME, "<nickname> :Erroneus nickname"},
			{ErrorCodes.NICKNAMEINUSE, "<nickname> :Nickname is already in use"},
			{ErrorCodes.NICKCOLLISION, "<nickname> :Nickname collision KILL"},
			{ErrorCodes.USERNOTINCHANNEL, "<nickname> <channel> :They aren't on that channel"},
			{ErrorCodes.NOTONCHANNEL, "<channelname> :You're not on that channel"},
			{ErrorCodes.USERONCHANNEL, "<user> <channel> :is already on channel"},
			{ErrorCodes.NOLOGIN, "<user> :User not logged in"},
			{ErrorCodes.SUMMONDISABLED, ":SUMMON has been disabled"},
			{ErrorCodes.USERSDISABLED, ":USERS has been disabled"},
			{ErrorCodes.NOTREGISTERED, ":You have not registered"},
			{ErrorCodes.NEEDMOREPARAMS, "<command> :Not enough parameters"},
			{ErrorCodes.ALREADYREGISTRED, ":You may not reregister"},
			{ErrorCodes.NOPERMFORHOST, ":Your host isn't among the privileged"},
			{ErrorCodes.PASSWDMISMATCH, ":Password incorrect"},
			{ErrorCodes.YOUREBANNEDCREEP, ":You are banned from this server"},
			{ErrorCodes.KEYSET, "<channelname> :Channel key already set"},
			{ErrorCodes.CHANNELISFULL, "<channelname> :Cannot join channel (+l)"},
			{ErrorCodes.UNKNOWNMODE, "<char> :is unknown mode char to me"},
			{ErrorCodes.INVITEONLYCHAN, "<channelname> :Cannot join channel (+i)"},
			{ErrorCodes.BANNEDFROMCHAN, "<channelname> :Cannot join channel (+b)"},
			{ErrorCodes.BADCHANNELKEY, "<channelname> :Cannot join channel (+k)"},
			{ErrorCodes.NOPRIVILEGES, ":Permission Denied- You're not an IRC operator"},
			{ErrorCodes.CHANOPRIVSNEEDED, "<channelname> :You're not channel operator"},
			{ErrorCodes.CANTKILLSERVER, ":You cant kill a server!"},
			{ErrorCodes.NOOPERHOST, ":No O-lines for your host"},
			{ErrorCodes.UMODEUNKNOWNFLAG, ":Unknown MODE flag"},
			{ErrorCodes.USERSDONTMATCH, ":Cant change mode for other users"},
		};
		#endregion
		#region Reply Messages
		Dictionary<ReplyCodes, string> replyMessages = new Dictionary<ReplyCodes, string> {
			{ReplyCodes.NONE, "Dummy reply number. Not used."},
			{ReplyCodes.USERHOST, ":[<reply>{<space><nickname>}]"},
			{ReplyCodes.ISON, ":[<nickname> {<space><nickname>}]"},
			{ReplyCodes.AWAY, "<nickname> :<message>"},
			{ReplyCodes.UNAWAY, ":You are no longer marked as being away"},
			{ReplyCodes.NOWAWAY, ":You have been marked as being away"},
			{ReplyCodes.WHOISUSER, "<nickname> <user> <host> * :<realname>"},
			{ReplyCodes.WHOISSERVER, "<nickname> <servername> :<serverinfo>"},
			{ReplyCodes.WHOISOPERATOR, "<nickname> :is an IRC operator"},
			{ReplyCodes.WHOISIDLE, "<nickname> <integer> :seconds idle"},
			{ReplyCodes.ENDOFWHOIS, "<nickname> :End of /WHOIS list"},
			{ReplyCodes.WHOISCHANNELS, "<nickname> :{[@|+]<channel><space>}"},
			{ReplyCodes.WHOWASUSER, "<nickname> <user> <host> * :<realname>"},
			{ReplyCodes.ENDOFWHOWAS, "<nickname> :End of WHOWAS"},
			{ReplyCodes.LISTSTART, "Channel :Users  Name"},
			{ReplyCodes.LIST, "<channelname> <# visible> :<topic>"},
			{ReplyCodes.LISTEND, ":End of /LIST"},
			{ReplyCodes.CHANNELMODEIS, "<channelname> <mode> <mode params>"},
			{ReplyCodes.NOTOPIC, "<channelname> :No topic is set"},
			{ReplyCodes.TOPIC, "<channelname> :<topic>"},
			{ReplyCodes.INVITING, "<channelname> <nick>"},
			{ReplyCodes.SUMMONING, "<user> :Summoning user to IRC"},
			{ReplyCodes.VERSION, "<version>.<debuglevel> <servername> :<comments>"},
			{ReplyCodes.WHOREPLY, "<channelname> <user> <host> <servername> <nick> <H|G>[*][@|+] :<hopcount> <realname>"},
			{ReplyCodes.ENDOFWHO, "<nickname> :End of /WHO list"},
			{ReplyCodes.NAMREPLY, "<channelname> :[[@|+]<nick> [[@|+]<nick> [...]]]"},
			{ReplyCodes.ENDOFNAMES, "<channelname> :End of /NAMES list"},
			{ReplyCodes.LINKS, "<mask> <servername> :<hopcount> <server info>"},
			{ReplyCodes.ENDOFLINKS, "<mask> :End of /LINKS list"},
			{ReplyCodes.BANLIST, "<channelname> <banid>"},
			{ReplyCodes.ENDOFBANLIST, "<channelname> :End of channel ban list"},
			{ReplyCodes.INFO, ":<string>"},
			{ReplyCodes.ENDOFINFO, ":End of /INFO list"},
			{ReplyCodes.MOTDSTART, ":- <servername> Message of the day - "},
			{ReplyCodes.MOTD, ":- <text>"},
			{ReplyCodes.ENDOFMOTD, ":End of /MOTD command"},
			{ReplyCodes.YOUREOPER, ":You are now an IRC operator"},
			{ReplyCodes.REHASHING, "<configfile> :Rehashing"},
			{ReplyCodes.TIME, "<server> :<string showing server's local time>"},
			{ReplyCodes.USERSSTART, ":UserID   Terminal  Host"},
			{ReplyCodes.USERS, ":%-8s %-9s %-8s"},
			{ReplyCodes.ENDOFUSERS, ":End of users"},
			{ReplyCodes.NOUSERS, ":Nobody logged in"},
			// not implemented
			{ReplyCodes.TRACELINK, "Link <version & debug level> <destination> <next server>"},
			{ReplyCodes.TRACECONNECTING, "Try. <class> <server>"},
			{ReplyCodes.TRACEHANDSHAKE, "H.S. <class> <server>"},
			{ReplyCodes.TRACEUNKNOWN, "???? <class> [<client IP address in dot form>]"},
			{ReplyCodes.TRACEOPERATOR, "Oper <class> <nickname>"},
			{ReplyCodes.TRACEUSER, "User <class> <nick>"},
			{ReplyCodes.TRACESERVER, "Serv <class> <int>S <int>C <server> <nickname!user|*!*>@<host|server>"},
			{ReplyCodes.TRACENEWTYPE, "<newtype> 0 <client name>"},
			{ReplyCodes.TRACELOG, "File <logfile> <debug level>"},
			{ReplyCodes.STATSLINKINFO, "<linkname> <sendq> <sent messages> <sent bytes> <received messages> <received bytes> <time open>"},
			{ReplyCodes.STATSCOMMANDS, "<command> <count>"},
			{ReplyCodes.STATSCLINE, "C <host> * <name> <port> <class>"},
			{ReplyCodes.STATSNLINE, "N <host> * <name> <port> <class>"},
			{ReplyCodes.STATSILINE, "I <host> * <host> <port> <class>"},
			{ReplyCodes.STATSKLINE, "K <host> * <username> <port> <class>"},
			{ReplyCodes.STATSYLINE, "Y <class> <ping frequency> <connect frequency> <max sendq>"},
			{ReplyCodes.ENDOFSTATS, "<stats letter> :End of /STATS report"},
			{ReplyCodes.STATSLLINE, "L <hostmask> * <servername> <maxdepth>"},
			{ReplyCodes.STATSUPTIME, ":Server Up %d days %d:%02d:%02d"},
			{ReplyCodes.STATSOLINE, "O <hostmask> * <name>"},
			{ReplyCodes.STATSHLINE, "H <hostmask> * <servername>"},
			// /end of not implemented. May be someone else can do this.
			{ReplyCodes.UMODEIS, "<user mode string>"},
			{ReplyCodes.LUSERCLIENT, ":There are <integer> users and <integer> invisible on <integer> servers"},
			{ReplyCodes.LUSEROP, "<integer> :operator(s) online"},
			{ReplyCodes.LUSERUNKNOWN, "<integer> :unknown connection(s)"},
			{ReplyCodes.LUSERCHANNELS, "<integer> :channels formed"},
			{ReplyCodes.LUSERME, ":I have <integer> clients and <integer> servers"},
			{ReplyCodes.ADMINME, "<servername> :Administrative info"},
			{ReplyCodes.ADMINLOC1, ":<admininfo>"},
			{ReplyCodes.ADMINLOC2, ":<admininfo>"},
			{ReplyCodes.ADMINEMAIL, ":<admininfo>"},
		};

		#endregion

		public IRCSettings Settings;

		List<Connection> connections;
		TcpListener listener;

		public void Initialize()
		{
			LogAction("loading", "settings", loadSettings);
			LogAction("loading", "database", initDatabase);
		}
		public void Run()
		{
			LogAction("initializing", "Network Interfaces", initNetwork);
		}
		public void Log(string message) {
			Trace.TraceInformation(message);
		}
		public void LogConnection(Connection connection, string message) {
			Trace.TraceInformation(string.Format("{0} {1}", string.IsNullOrWhiteSpace(connection.Nick) ? connection.IPAddress.ToString() : connection.Nick, message));
		}
		public void LogAction(string prefix, string name, Action action)
		{
			Trace.TraceInformation("{0} {1}", prefix, name);
			action();
			Trace.TraceInformation("done: {0} {1}", prefix, name);
		}
		public void Disconnect(Connection connection)
		{
			connections.Remove(connection);
		}
		public void Error(Connection connection, ErrorCodes errorCode, Dictionary<string, string> resolve)
		{
			string text = errorMessages[errorCode];
			foreach (KeyValuePair<string, string> item in resolve)
				text = text.Replace("<" + item.Key + ">", item.Value);
			connection.Send(string.Format("ERROR {0} {1}", (int)errorCode, text));
		}
		public void Reply(Connection connection, ReplyCodes replyCode, Dictionary<string, string> resolve) {
			string text = replyMessages[replyCode];
			foreach (KeyValuePair<string, string> item in resolve)
				text = text.Replace("<" + item.Key + ">", item.Value);
			connection.Send(string.Format(":{0} {1} {2} :{3}", Settings.Name, (int)replyCode, connection.Nick, text));
		}

		public void ExecuteAction(Connection connection, string line) {
			Log(line);
			string[] command = line.Split(' ');
			switch (command[0].ToLowerInvariant())
			{
				case "pass":
					passConnection(connection, command.Skip(1).ToArray());
					break;
				case "nick":
					nickConnection(connection, command.Skip(1).ToArray());
					break;
				case "pong":
					pongConnection(connection, command.Skip(1).ToArray());
					break;
				case "user":
					userConnection(connection, command.Skip(1).ToArray());
					break;
				case "join":
					break;
				case "quit":
					quitConnection(connection, command.Skip(1).ToArray());
					break;

				default:
					Trace.TraceWarning(line);
					break;
			}
			if (command[0].StartsWith(":"))
			{
				if (connection.Nick.ToLowerInvariant() == command[0].Substring(1).ToLowerInvariant())
				{
					ExecuteAction(connection, string.Join(" ", command.Skip(1)));
				}
			}
		}

		public bool HasNick(string nick)
		{
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
		private void passConnection(Connection connection, params string[] args)
		{
			if (args.Length > 0)
			{
				if (!connection.Registered)
				{
					LogConnection(connection, "set password");
					connection.Pass = args[0];
				}
				else
				{
					Error(connection, ErrorCodes.ALREADYREGISTRED, new Dictionary<string, string>());
				}
			}
			else
			{
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
		private void nickConnection(Connection connection, params string[] args)
		{
			if (args.Length > 0)
			{
				if (!HasNick(args[0]))
				{
					LogConnection(connection, "set nick to " + args[0]);
					connection.Nick = args[0];
				}
				else
				{
					Error(connection, ErrorCodes.NICKNAMEINUSE, new Dictionary<string, string> { { "nickname", args[0] } });
				}
			}
			else
			{
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
		private void pongConnection(Connection connection, params string[] args)
		{
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
		private void quitConnection(Connection connection, params string[] args)
		{
			if (args.Length > 0)
			{
				connection.Disconnect(string.Join(" ", args));
			}
			else
			{
				connection.Disconnect();
			}
		}
		/// <summary>
		/// Toggles away-state of connection
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="args"></param>
		private void awayConnection(Connection connection, params string[] args)
		{
			if (args.Length > 0)
				connection.Away = true;
			else
				connection.Away = false;
		}
		/// <summary>
		/// Authenticates user.
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="args"></param>
		private void userConnection(Connection connection, params string[] args) {
			if (args.Length > 3) {
				connection.Username = args[0];
				connection.Hostname = args[1];
				connection.Servername = args[2];
				connection.Realname = string.Concat(args.Skip(3));
				if (connection.Realname.StartsWith(":"))
					connection.Realname = connection.Realname.Substring(1);
				LogConnection(connection, string.Format("Set User to {{Username: {0}, Hostname: {1}, Servername: {2}, Realname: {3}}}", connection.Nick, connection.Hostname, connection.Servername, connection.Realname));
			} else {
				Error(connection, ErrorCodes.NEEDMOREPARAMS, new Dictionary<string, string> { { "command", "USER" } });
			}
		}
		/// <summary>
		/// User joins channel.
		/// </summary>
		/// <param name="connection"></param>
		/// <param name="args"></param>
		private void joinConnection(Connection connection, params string[] args) {
			if (args.Length > 0) {

			} else {
				Error(connection, ErrorCodes.NEEDMOREPARAMS, new Dictionary<string, string> { { "command", "JOIN" } });
			}
		}

		private void initNetwork()
		{
			connections = new List<Connection>();
			listener = new TcpListener(IPAddress.Parse(Settings.Address), Settings.Port);
			listener.Start();
			listener.BeginAcceptTcpClient(acceptTcp, null);
		}
		private void acceptTcp(IAsyncResult result)
		{
			TcpClient client = listener.EndAcceptTcpClient(result);
			Trace.TraceInformation("New Connection of IP {0}", client.Client.RemoteEndPoint);
			connections.Add(new Connection(this, client));
			listener.BeginAcceptTcpClient(acceptTcp, null);
		}
		private void initDatabase()
		{
			using (DatabaseContext database = new DatabaseContext())
			{
				MigrateDatabaseToLatestVersion<DatabaseContext, Configuration> migrate = new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>();
				Database.SetInitializer<DatabaseContext>(migrate);
				migrate.InitializeDatabase(database);
			}
		}
		private void loadSettings()
		{
			Settings = new IRCSettings();
			Settings.Load();
		}
	}
}
