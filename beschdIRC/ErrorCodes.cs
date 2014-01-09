namespace beschdIRC
{
	public enum ErrorCodes
	{
		/// <summary>
		/// Used to indicate the nickname parameter supplied to a command is currently unused.
		/// </summary>
		///<remarks>
		/// <para>&lt;nickname&gt; :No such nick/channel</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOSUCHNICK = 401,
		/// <summary>
		/// Used to indicate the server name given currently doesn&#39;t exist.
		/// </summary>
		///<remarks>
		/// <para>&lt;server name&gt; :No such server</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOSUCHSERVER = 402,
		/// <summary>
		/// Used to indicate the given channel name is invalid.
		/// </summary>
		///<remarks>
		/// <para>&lt;channel name&gt; :No such channel</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOSUCHCHANNEL = 403,
		/// <summary>
		/// Sent to a user who is either (a) not on a channel which is mode +n or (b) not a chanop (or mode +v) on a channel which has mode +m set and is trying to send a PRIVMSG message to that channel.
		/// </summary>
		///<remarks>
		/// <para>&lt;channel name&gt; :Cannot send to channel</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		CANNOTSENDTOCHAN = 404,
		/// <summary>
		/// Sent to a user when they have joined the maximum number of allowed channels and they try to join another channel.
		/// </summary>
		///<remarks>
		/// <para>&lt;channel name&gt; :You have joined too many channels</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		TOOMANYCHANNELS = 405,
		/// <summary>
		/// Returned by WHOWAS to indicate there is no history information for that nickname.
		/// </summary>
		///<remarks>
		/// <para>&lt;nickname&gt; :There was no such nickname</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		WASNOSUCHNICK = 406,
		/// <summary>
		/// Returned to a client which is attempting to send a PRIVMSG/NOTICE using the user@host destination format and for a user@host which has several occurrences.
		/// </summary>
		///<remarks>
		/// <para>&lt;target&gt; :Duplicate recipients. No message delivered</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		TOOMANYTARGETS = 407,
		/// <summary>
		/// PING or PONG message missing the originator parameter which is required since these commands must work without valid prefixes.
		/// </summary>
		///<remarks>
		/// <para>:No origin specified</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOORIGIN = 409,
		/// <summary>
		/// returned by PRIVMSG to indicate that the message wasn&#39;t delivered for some reason. ERR_NOTOPLEVEL and ERR_WILDTOPLEVEL are errors that are returned when an invalid use of &quot;PRIVMSG $&lt;server&gt;&quot; or &quot;PRIVMSG #&lt;host&gt;&quot; is attempted.
		/// </summary>
		///<remarks>
		/// <para>:No recipient given (&lt;command&gt;)</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NORECIPIENT = 411,
		/// <summary>
		/// returned by PRIVMSG to indicate that the message wasn&#39;t delivered for some reason. ERR_NOTOPLEVEL and ERR_WILDTOPLEVEL are errors that are returned when an invalid use of &quot;PRIVMSG $&lt;server&gt;&quot; or &quot;PRIVMSG #&lt;host&gt;&quot; is attempted.
		/// </summary>
		///<remarks>
		/// <para>:No text to send</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOTEXTTOSEND = 412,
		/// <summary>
		/// returned by PRIVMSG to indicate that the message wasn&#39;t delivered for some reason. ERR_NOTOPLEVEL and ERR_WILDTOPLEVEL are errors that are returned when an invalid use of &quot;PRIVMSG $&lt;server&gt;&quot; or &quot;PRIVMSG #&lt;host&gt;&quot; is attempted.
		/// </summary>
		///<remarks>
		/// <para>&lt;mask&gt; :No toplevel domain specified</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOTOPLEVEL = 413,
		/// <summary>
		/// returned by PRIVMSG to indicate that the message wasn&#39;t delivered for some reason. ERR_NOTOPLEVEL and ERR_WILDTOPLEVEL are errors that are returned when an invalid use of &quot;PRIVMSG $&lt;server&gt;&quot; or &quot;PRIVMSG #&lt;host&gt;&quot; is attempted.
		/// </summary>
		///<remarks>
		/// <para>&lt;mask&gt; :Wildcard in toplevel domain</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		WILDTOPLEVEL = 414,
		/// <summary>
		/// Returned to a registered client to indicate that the command sent is unknown by the server.
		/// </summary>
		///<remarks>
		/// <para>&lt;command&gt; :Unknown command</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		UNKNOWNCOMMAND = 421,
		/// <summary>
		/// Server&#39;s MOTD file could not be opened by the server.
		/// </summary>
		///<remarks>
		/// <para>:MOTD File is missing</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOMOTD = 422,
		/// <summary>
		/// Returned by a server in response to an ADMIN message when there is an error in finding the appropriate information.
		/// </summary>
		///<remarks>
		/// <para>&lt;server&gt; :No administrative info available</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOADMININFO = 423,
		/// <summary>
		/// Generic error message used to report a failed file operation during the processing of a message.
		/// </summary>
		///<remarks>
		/// <para>:File error doing &lt;file op&gt; on &lt;file&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		FILEERROR = 424,
		/// <summary>
		/// Returned when a nickname parameter expected for a command and isn&#39;t found.
		/// </summary>
		///<remarks>
		/// <para>:No nickname given</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NONICKNAMEGIVEN = 431,
		/// <summary>
		/// Returned after receiving a NICK message which contains characters which do not fall in the defined set.  See section x.x.x for details on valid nicknames.
		/// </summary>
		///<remarks>
		/// <para>&lt;nick&gt; :Erroneus nickname</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ERRONEUSNICKNAME = 432,
		/// <summary>
		/// Returned when a NICK message is processed that results in an attempt to change to a currently existing nickname.
		/// </summary>
		///<remarks>
		/// <para>&lt;nick&gt; :Nickname is already in use</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NICKNAMEINUSE = 433,
		/// <summary>
		/// Returned by a server to a client when it detects a nickname collision (registered of a NICK that already exists by another server).
		/// </summary>
		///<remarks>
		/// <para>&lt;nick&gt; :Nickname collision KILL</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NICKCOLLISION = 436,
		/// <summary>
		/// Returned by the server to indicate that the target user of the command is not on the given channel.
		/// </summary>
		///<remarks>
		/// <para>&lt;nick&gt; &lt;channel&gt; :They aren&#39;t on that channel</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		USERNOTINCHANNEL = 441,
		/// <summary>
		/// Returned by the server whenever a client tries to perform a channel effecting command for which the client isn&#39;t a member.
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; :You&#39;re not on that channel</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOTONCHANNEL = 442,
		/// <summary>
		/// Returned when a client tries to invite a user to a channel they are already on.
		/// </summary>
		///<remarks>
		/// <para>&lt;user&gt; &lt;channel&gt; :is already on channel</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		USERONCHANNEL = 443,
		/// <summary>
		/// Returned by the summon after a SUMMON command for a user was unable to be performed since they were not logged in.
		/// </summary>
		///<remarks>
		/// <para>&lt;user&gt; :User not logged in</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOLOGIN = 444,
		/// <summary>
		/// Returned as a response to the SUMMON command.  Must be returned by any server which does not implement it.
		/// </summary>
		///<remarks>
		/// <para>:SUMMON has been disabled</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		SUMMONDISABLED = 445,
		/// <summary>
		/// Returned as a response to the USERS command.  Must be returned by any server which does not implement it.
		/// </summary>
		///<remarks>
		/// <para>:USERS has been disabled</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		USERSDISABLED = 446,
		/// <summary>
		/// Returned by the server to indicate that the client must be registered before the server will allow it to be parsed in detail.
		/// </summary>
		///<remarks>
		/// <para>:You have not registered</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOTREGISTERED = 451,
		/// <summary>
		/// Returned by the server by numerous commands to indicate to the client that it didn&#39;t supply enough parameters.
		/// </summary>
		///<remarks>
		/// <para>&lt;command&gt; :Not enough parameters</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NEEDMOREPARAMS = 461,
		/// <summary>
		/// Returned by the server to any link which tries to change part of the registered details (such as password or user details from second USER message).
		/// </summary>
		///<remarks>
		/// <para>:You may not reregister</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ALREADYREGISTRED = 462,
		/// <summary>
		/// Returned to a client which attempts to register with a server which does not been setup to allow connections from the host the attempted connection is tried.
		/// </summary>
		///<remarks>
		/// <para>:Your host isn&#39;t among the privileged</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOPERMFORHOST = 463,
		/// <summary>
		/// Returned to indicate a failed attempt at registering a connection for which a password was required and was either not given or incorrect.
		/// </summary>
		///<remarks>
		/// <para>:Password incorrect</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		PASSWDMISMATCH = 464,
		/// <summary>
		/// Returned after an attempt to connect and register yourself with a server which has been setup to explicitly deny connections to you.
		/// </summary>
		///<remarks>
		/// <para>:You are banned from this server</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		YOUREBANNEDCREEP = 465,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; :Channel key already set</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		KEYSET = 467,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; :Cannot join channel (+l)</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		CHANNELISFULL = 471,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>&lt;char&gt; :is unknown mode char to me</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		UNKNOWNMODE = 472,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; :Cannot join channel (+i)</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		INVITEONLYCHAN = 473,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; :Cannot join channel (+b)</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		BANNEDFROMCHAN = 474,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; :Cannot join channel (+k)</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		BADCHANNELKEY = 475,
		/// <summary>
		/// Any command requiring operator privileges to operate must return this error to indicate the attempt was unsuccessful.
		/// </summary>
		///<remarks>
		/// <para>:Permission Denied- You&#39;re not an IRC operator</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOPRIVILEGES = 481,
		/// <summary>
		/// Any command requiring &#39;chanop&#39; privileges (such as MODE messages) must return this error if the client making the attempt is not a chanop on the specified channel.
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; :You&#39;re not channel operator</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		CHANOPRIVSNEEDED = 482,
		/// <summary>
		/// Any attempts to use the KILL command on a server are to be refused and this error returned directly to the client.
		/// </summary>
		///<remarks>
		/// <para>:You cant kill a server!</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		CANTKILLSERVER = 483,
		/// <summary>
		/// If a client sends an OPER message and the server has not been configured to allow connections from the client&#39;s host as an operator, this error must be returned.
		/// </summary>
		///<remarks>
		/// <para>:No O-lines for your host</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOOPERHOST = 491,
		/// <summary>
		/// Returned by the server to indicate that a MODE message was sent with a nickname parameter and that the a mode flag sent was not recognized.
		/// </summary>
		///<remarks>
		/// <para>:Unknown MODE flag</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		UMODEUNKNOWNFLAG = 501,
		/// <summary>
		/// Error sent to any user trying to view or change the user mode for a user other than themselves.
		/// </summary>
		///<remarks>
		/// <para>:Cant change mode for other users</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		USERSDONTMATCH = 502,
	}
}