namespace beschdIRC {
	public enum ReplyCodes {
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>Dummy reply number. Not used.</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NONE = 300,
		/// <summary>
		/// Reply format used by USERHOST to list replies to the query list.  The reply string is composed as follows: &lt;reply&gt; ::= &lt;nick&gt;[&#39;*&#39;] &#39;=&#39; &lt;&#39;+&#39;|&#39;-&#39;&gt;&lt;hostname&gt; The &#39;*&#39; indicates whether the client has registered as an Operator.  The &#39;-&#39; or &#39;+&#39; characters represent whether the client has set an AWAY message or not respectively.
		/// </summary>
		///<remarks>
		/// <para>:[&lt;reply&gt;{&lt;space&gt;&lt;reply&gt;}]</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		USERHOST = 302,
		/// <summary>
		/// Reply format used by ISON to list replies to the query list.
		/// </summary>
		///<remarks>
		/// <para>:[&lt;nick&gt; {&lt;space&gt;&lt;nick&gt;}]</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ISON = 303,
		/// <summary>
		/// These replies are used with the AWAY command (if allowed).  RPL_AWAY is sent to any client sending a PRIVMSG to a client which is away.  RPL_AWAY is only sent by the server to which the client is connected. Replies RPL_UNAWAY and RPL_NOWAWAY are sent when the client removes and sets an AWAY message.
		/// </summary>
		///<remarks>
		/// <para>&lt;nick&gt; :&lt;away message&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		AWAY = 301,
		/// <summary>
		/// These replies are used with the AWAY command (if allowed).  RPL_AWAY is sent to any client sending a PRIVMSG to a client which is away.  RPL_AWAY is only sent by the server to which the client is connected. Replies RPL_UNAWAY and RPL_NOWAWAY are sent when the client removes and sets an AWAY message.
		/// </summary>
		///<remarks>
		/// <para>:You are no longer marked as being away</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		UNAWAY = 305,
		/// <summary>
		/// These replies are used with the AWAY command (if allowed).  RPL_AWAY is sent to any client sending a PRIVMSG to a client which is away.  RPL_AWAY is only sent by the server to which the client is connected. Replies RPL_UNAWAY and RPL_NOWAWAY are sent when the client removes and sets an AWAY message.
		/// </summary>
		///<remarks>
		/// <para>:You have been marked as being away</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOWAWAY = 306,
		/// <summary>
		/// Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message.  Given that there are enough parameters present, the answering server must either formulate a reply out of the above numerics (if the query nick is found) or return an error reply.  The &#39;*&#39; in RPL_WHOISUSER is there as the literal character and not as a wild card.  For each reply set, only RPL_WHOISCHANNELS may appear more than once (for long lists of channel names). The &#39;@&#39; and &#39;+&#39; characters next to the channel name indicate whether a client is a channel operator or has been granted permission to speak on a moderated channel.  The RPL_ENDOFWHOIS reply is used to mark the end of processing a WHOIS message.
		/// </summary>
		///<remarks>
		/// <para>&lt;nick&gt; &lt;user&gt; &lt;host&gt; * :&lt;real name&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		WHOISUSER = 311,
		/// <summary>
		/// Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message.  Given that there are enough parameters present, the answering server must either formulate a reply out of the above numerics (if the query nick is found) or return an error reply.  The &#39;*&#39; in RPL_WHOISUSER is there as the literal character and not as a wild card.  For each reply set, only RPL_WHOISCHANNELS may appear more than once (for long lists of channel names). The &#39;@&#39; and &#39;+&#39; characters next to the channel name indicate whether a client is a channel operator or has been granted permission to speak on a moderated channel.  The RPL_ENDOFWHOIS reply is used to mark the end of processing a WHOIS message.
		/// </summary>
		///<remarks>
		/// <para>&lt;nick&gt; &lt;server&gt; :&lt;server info&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		WHOISSERVER = 312,
		/// <summary>
		/// Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message.  Given that there are enough parameters present, the answering server must either formulate a reply out of the above numerics (if the query nick is found) or return an error reply.  The &#39;*&#39; in RPL_WHOISUSER is there as the literal character and not as a wild card.  For each reply set, only RPL_WHOISCHANNELS may appear more than once (for long lists of channel names). The &#39;@&#39; and &#39;+&#39; characters next to the channel name indicate whether a client is a channel operator or has been granted permission to speak on a moderated channel.  The RPL_ENDOFWHOIS reply is used to mark the end of processing a WHOIS message.
		/// </summary>
		///<remarks>
		/// <para>&lt;nick&gt; :is an IRC operator</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		WHOISOPERATOR = 313,
		/// <summary>
		/// Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message.  Given that there are enough parameters present, the answering server must either formulate a reply out of the above numerics (if the query nick is found) or return an error reply.  The &#39;*&#39; in RPL_WHOISUSER is there as the literal character and not as a wild card.  For each reply set, only RPL_WHOISCHANNELS may appear more than once (for long lists of channel names). The &#39;@&#39; and &#39;+&#39; characters next to the channel name indicate whether a client is a channel operator or has been granted permission to speak on a moderated channel.  The RPL_ENDOFWHOIS reply is used to mark the end of processing a WHOIS message.
		/// </summary>
		///<remarks>
		/// <para>&lt;nick&gt; &lt;integer&gt; :seconds idle</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		WHOISIDLE = 317,
		/// <summary>
		/// Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message.  Given that there are enough parameters present, the answering server must either formulate a reply out of the above numerics (if the query nick is found) or return an error reply.  The &#39;*&#39; in RPL_WHOISUSER is there as the literal character and not as a wild card.  For each reply set, only RPL_WHOISCHANNELS may appear more than once (for long lists of channel names). The &#39;@&#39; and &#39;+&#39; characters next to the channel name indicate whether a client is a channel operator or has been granted permission to speak on a moderated channel.  The RPL_ENDOFWHOIS reply is used to mark the end of processing a WHOIS message.
		/// </summary>
		///<remarks>
		/// <para>&lt;nick&gt; :End of /WHOIS list</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ENDOFWHOIS = 318,
		/// <summary>
		/// Replies 311 - 313, 317 - 319 are all replies generated in response to a WHOIS message.  Given that there are enough parameters present, the answering server must either formulate a reply out of the above numerics (if the query nick is found) or return an error reply.  The &#39;*&#39; in RPL_WHOISUSER is there as the literal character and not as a wild card.  For each reply set, only RPL_WHOISCHANNELS may appear more than once (for long lists of channel names). The &#39;@&#39; and &#39;+&#39; characters next to the channel name indicate whether a client is a channel operator or has been granted permission to speak on a moderated channel.  The RPL_ENDOFWHOIS reply is used to mark the end of processing a WHOIS message.
		/// </summary>
		///<remarks>
		/// <para>&lt;nick&gt; :{[@|+]&lt;channel&gt;&lt;space&gt;}</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		WHOISCHANNELS = 319,
		/// <summary>
		/// When replying to a WHOWAS message, a server must use the replies RPL_WHOWASUSER, RPL_WHOISSERVER or ERR_WASNOSUCHNICK for each nickname in the presented list.  At the end of all reply batches, there must be RPL_ENDOFWHOWAS (even if there was only one reply and it was an error).
		/// </summary>
		///<remarks>
		/// <para>&lt;nick&gt; &lt;user&gt; &lt;host&gt; * :&lt;real name&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		WHOWASUSER = 314,
		/// <summary>
		/// When replying to a WHOWAS message, a server must use the replies RPL_WHOWASUSER, RPL_WHOISSERVER or ERR_WASNOSUCHNICK for each nickname in the presented list.  At the end of all reply batches, there must be RPL_ENDOFWHOWAS (even if there was only one reply and it was an error).
		/// </summary>
		///<remarks>
		/// <para>&lt;nick&gt; :End of WHOWAS</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ENDOFWHOWAS = 369,
		/// <summary>
		/// Replies RPL_LISTSTART, RPL_LIST, RPL_LISTEND mark the start, actual replies with data and end of the server&#39;s response to a LIST command.  If there are no channels available to return, only the start and end reply must be sent.
		/// </summary>
		///<remarks>
		/// <para>Channel :Users  Name</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		LISTSTART = 321,
		/// <summary>
		/// Replies RPL_LISTSTART, RPL_LIST, RPL_LISTEND mark the start, actual replies with data and end of the server&#39;s response to a LIST command.  If there are no channels available to return, only the start and end reply must be sent.
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; &lt;# visible&gt; :&lt;topic&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		LIST = 322,
		/// <summary>
		/// Replies RPL_LISTSTART, RPL_LIST, RPL_LISTEND mark the start, actual replies with data and end of the server&#39;s response to a LIST command.  If there are no channels available to return, only the start and end reply must be sent.
		/// </summary>
		///<remarks>
		/// <para>:End of /LIST</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		LISTEND = 323,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; &lt;mode&gt; &lt;mode params&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		CHANNELMODEIS = 324,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; :No topic is set</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOTOPIC = 331,
		/// <summary>
		/// When sending a TOPIC message to determine the channel topic, one of two replies is sent.  If the topic is set, RPL_TOPIC is sent back else RPL_NOTOPIC.
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; :&lt;topic&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		TOPIC = 332,
		/// <summary>
		/// Returned by the server to indicate that the attempted INVITE message was successful and is being passed onto the end client.
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; &lt;nick&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		INVITING = 341,
		/// <summary>
		/// Returned by a server answering a SUMMON message to indicate that it is summoning that user.
		/// </summary>
		///<remarks>
		/// <para>&lt;user&gt; :Summoning user to IRC</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		SUMMONING = 342,
		/// <summary>
		/// Reply by the server showing its version details. The &lt;version&gt; is the version of the software being used (including any patchlevel revisions) and the &lt;debuglevel&gt; is used to indicate if the server is running in &quot;debug mode&quot;. The &quot;comments&quot; field may contain any comments about the version or further version details.
		/// </summary>
		///<remarks>
		/// <para>&lt;version&gt;.&lt;debuglevel&gt; &lt;server&gt; :&lt;comments&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		VERSION = 351,
		/// <summary>
		/// The RPL_WHOREPLY and RPL_ENDOFWHO pair are used to answer a WHO message.  The RPL_WHOREPLY is only sent if there is an appropriate match to the WHO query.  If there is a list of parameters supplied with a WHO message, a RPL_ENDOFWHO must be sent after processing each list item with &lt;name&gt; being the item.
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; &lt;user&gt; &lt;host&gt; &lt;server&gt; &lt;nick&gt; &lt;H|G&gt;[*][@|+] :&lt;hopcount&gt; &lt;real name&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		WHOREPLY = 352,
		/// <summary>
		/// The RPL_WHOREPLY and RPL_ENDOFWHO pair are used to answer a WHO message.  The RPL_WHOREPLY is only sent if there is an appropriate match to the WHO query.  If there is a list of parameters supplied with a WHO message, a RPL_ENDOFWHO must be sent after processing each list item with &lt;name&gt; being the item.
		/// </summary>
		///<remarks>
		/// <para>&lt;name&gt; :End of /WHO list</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ENDOFWHO = 315,
		/// <summary>
		/// To reply to a NAMES message, a reply pair consisting of RPL_NAMREPLY and RPL_ENDOFNAMES is sent by the server back to the client.  If there is no channel found as in the query, then only RPL_ENDOFNAMES is returned.  The exception to this is when a NAMES message is sent with no parameters and all visible channels and contents are sent back in a series of RPL_NAMEREPLY messages with a RPL_ENDOFNAMES to mark the end.
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; :[[@|+]&lt;nick&gt; [[@|+]&lt;nick&gt; [...]]]</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NAMREPLY = 353,
		/// <summary>
		/// To reply to a NAMES message, a reply pair consisting of RPL_NAMREPLY and RPL_ENDOFNAMES is sent by the server back to the client.  If there is no channel found as in the query, then only RPL_ENDOFNAMES is returned.  The exception to this is when a NAMES message is sent with no parameters and all visible channels and contents are sent back in a series of RPL_NAMEREPLY messages with a RPL_ENDOFNAMES to mark the end.
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; :End of /NAMES list</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ENDOFNAMES = 366,
		/// <summary>
		/// In replying to the LINKS message, a server must send replies back using the RPL_LINKS numeric and mark the end of the list using an RPL_ENDOFLINKS reply.
		/// </summary>
		///<remarks>
		/// <para>&lt;mask&gt; &lt;server&gt; :&lt;hopcount&gt; &lt;server info&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		LINKS = 364,
		/// <summary>
		/// In replying to the LINKS message, a server must send replies back using the RPL_LINKS numeric and mark the end of the list using an RPL_ENDOFLINKS reply.
		/// </summary>
		///<remarks>
		/// <para>&lt;mask&gt; :End of /LINKS list</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ENDOFLINKS = 365,
		/// <summary>
		/// When listing the active &#39;bans&#39; for a given channel, a server is required to send the list back using the RPL_BANLIST and RPL_ENDOFBANLIST messages.  A separate RPL_BANLIST is sent for each active banid.  After the banids have been listed (or if none present) a RPL_ENDOFBANLIST must be sent.
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; &lt;banid&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		BANLIST = 367,
		/// <summary>
		/// When listing the active &#39;bans&#39; for a given channel, a server is required to send the list back using the RPL_BANLIST and RPL_ENDOFBANLIST messages.  A separate RPL_BANLIST is sent for each active banid.  After the banids have been listed (or if none present) a RPL_ENDOFBANLIST must be sent.
		/// </summary>
		///<remarks>
		/// <para>&lt;channel&gt; :End of channel ban list</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ENDOFBANLIST = 368,
		/// <summary>
		/// A server responding to an INFO message is required to send all its &#39;info&#39; in a series of RPL_INFO messages with a RPL_ENDOFINFO reply to indicate the end of the replies.
		/// </summary>
		///<remarks>
		/// <para>:&lt;string&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		INFO = 371,
		/// <summary>
		/// A server responding to an INFO message is required to send all its &#39;info&#39; in a series of RPL_INFO messages with a RPL_ENDOFINFO reply to indicate the end of the replies.
		/// </summary>
		///<remarks>
		/// <para>:End of /INFO list</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ENDOFINFO = 374,
		/// <summary>
		/// When responding to the MOTD message and the MOTD file is found, the file is displayed line by line, with each line no longer than 80 characters, using RPL_MOTD format replies.  These should be surrounded by a RPL_MOTDSTART (before the RPL_MOTDs) and an RPL_ENDOFMOTD (after).
		/// </summary>
		///<remarks>
		/// <para>:- &lt;server&gt; Message of the day - </para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		MOTDSTART = 375,
		/// <summary>
		/// When responding to the MOTD message and the MOTD file is found, the file is displayed line by line, with each line no longer than 80 characters, using RPL_MOTD format replies.  These should be surrounded by a RPL_MOTDSTART (before the RPL_MOTDs) and an RPL_ENDOFMOTD (after).
		/// </summary>
		///<remarks>
		/// <para>:- &lt;text&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		MOTD = 372,
		/// <summary>
		/// When responding to the MOTD message and the MOTD file is found, the file is displayed line by line, with each line no longer than 80 characters, using RPL_MOTD format replies.  These should be surrounded by a RPL_MOTDSTART (before the RPL_MOTDs) and an RPL_ENDOFMOTD (after).
		/// </summary>
		///<remarks>
		/// <para>:End of /MOTD command</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ENDOFMOTD = 376,
		/// <summary>
		/// RPL_YOUREOPER is sent back to a client which has just successfully issued an OPER message and gained operator status.
		/// </summary>
		///<remarks>
		/// <para>:You are now an IRC operator</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		YOUREOPER = 381,
		/// <summary>
		/// If the REHASH option is used and an operator sends a REHASH message, an RPL_REHASHING is sent back to the operator.
		/// </summary>
		///<remarks>
		/// <para>&lt;config file&gt; :Rehashing</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		REHASHING = 382,
		/// <summary>
		/// When replying to the TIME message, a server must send the reply using the RPL_TIME format above.  The string showing the time need only contain the correct day and time there.  There is no further requirement for the time string.
		/// </summary>
		///<remarks>
		/// <para>&lt;server&gt; :&lt;string showing server&#39;s local time&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		TIME = 391,
		/// <summary>
		/// If the USERS message is handled by a server, the replies RPL_USERSTART, RPL_USERS, RPL_ENDOFUSERS and RPL_NOUSERS are used.  RPL_USERSSTART must be sent first, following by either a sequence of RPL_USERS or a single RPL_NOUSER.  Following this is RPL_ENDOFUSERS.
		/// </summary>
		///<remarks>
		/// <para>:UserID   Terminal  Host</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		USERSSTART = 392,
		/// <summary>
		/// If the USERS message is handled by a server, the replies RPL_USERSTART, RPL_USERS, RPL_ENDOFUSERS and RPL_NOUSERS are used.  RPL_USERSSTART must be sent first, following by either a sequence of RPL_USERS or a single RPL_NOUSER.  Following this is RPL_ENDOFUSERS.
		/// </summary>
		///<remarks>
		/// <para>:%-8s %-9s %-8s</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		USERS = 393,
		/// <summary>
		/// If the USERS message is handled by a server, the replies RPL_USERSTART, RPL_USERS, RPL_ENDOFUSERS and RPL_NOUSERS are used.  RPL_USERSSTART must be sent first, following by either a sequence of RPL_USERS or a single RPL_NOUSER.  Following this is RPL_ENDOFUSERS.
		/// </summary>
		///<remarks>
		/// <para>:End of users</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ENDOFUSERS = 394,
		/// <summary>
		/// If the USERS message is handled by a server, the replies RPL_USERSTART, RPL_USERS, RPL_ENDOFUSERS and RPL_NOUSERS are used.  RPL_USERSSTART must be sent first, following by either a sequence of RPL_USERS or a single RPL_NOUSER.  Following this is RPL_ENDOFUSERS.
		/// </summary>
		///<remarks>
		/// <para>:Nobody logged in</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		NOUSERS = 395,
		/// <summary>
		/// The RPL_TRACE* are all returned by the server in response to the TRACE message.  How many are returned is dependent on the the TRACE message and whether it was sent by an operator or not.  There is no predefined order for which occurs first. Replies RPL_TRACEUNKNOWN, RPL_TRACECONNECTING and RPL_TRACEHANDSHAKE are all used for connections which have not been fully established and are either unknown, still attempting to connect or in the process of completing the &#39;server handshake&#39;. RPL_TRACELINK is sent by any server which handles a TRACE message and has to pass it on to another server.  The list of RPL_TRACELINKs sent in response to a TRACE command traversing the IRC network should reflect the actual connectivity of the servers themselves along that path. RPL_TRACENEWTYPE is to be used for any connection which does not fit in the other categories but is being displayed anyway.
		/// </summary>
		///<remarks>
		/// <para>Link &lt;version &amp; debug level&gt; &lt;destination&gt; &lt;next server&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		TRACELINK = 200,
		/// <summary>
		/// The RPL_TRACE* are all returned by the server in response to the TRACE message.  How many are returned is dependent on the the TRACE message and whether it was sent by an operator or not.  There is no predefined order for which occurs first. Replies RPL_TRACEUNKNOWN, RPL_TRACECONNECTING and RPL_TRACEHANDSHAKE are all used for connections which have not been fully established and are either unknown, still attempting to connect or in the process of completing the &#39;server handshake&#39;. RPL_TRACELINK is sent by any server which handles a TRACE message and has to pass it on to another server.  The list of RPL_TRACELINKs sent in response to a TRACE command traversing the IRC network should reflect the actual connectivity of the servers themselves along that path. RPL_TRACENEWTYPE is to be used for any connection which does not fit in the other categories but is being displayed anyway.
		/// </summary>
		///<remarks>
		/// <para>Try. &lt;class&gt; &lt;server&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		TRACECONNECTING = 201,
		/// <summary>
		/// The RPL_TRACE* are all returned by the server in response to the TRACE message.  How many are returned is dependent on the the TRACE message and whether it was sent by an operator or not.  There is no predefined order for which occurs first. Replies RPL_TRACEUNKNOWN, RPL_TRACECONNECTING and RPL_TRACEHANDSHAKE are all used for connections which have not been fully established and are either unknown, still attempting to connect or in the process of completing the &#39;server handshake&#39;. RPL_TRACELINK is sent by any server which handles a TRACE message and has to pass it on to another server.  The list of RPL_TRACELINKs sent in response to a TRACE command traversing the IRC network should reflect the actual connectivity of the servers themselves along that path. RPL_TRACENEWTYPE is to be used for any connection which does not fit in the other categories but is being displayed anyway.
		/// </summary>
		///<remarks>
		/// <para>H.S. &lt;class&gt; &lt;server&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		TRACEHANDSHAKE = 202,
		/// <summary>
		/// The RPL_TRACE* are all returned by the server in response to the TRACE message.  How many are returned is dependent on the the TRACE message and whether it was sent by an operator or not.  There is no predefined order for which occurs first. Replies RPL_TRACEUNKNOWN, RPL_TRACECONNECTING and RPL_TRACEHANDSHAKE are all used for connections which have not been fully established and are either unknown, still attempting to connect or in the process of completing the &#39;server handshake&#39;. RPL_TRACELINK is sent by any server which handles a TRACE message and has to pass it on to another server.  The list of RPL_TRACELINKs sent in response to a TRACE command traversing the IRC network should reflect the actual connectivity of the servers themselves along that path. RPL_TRACENEWTYPE is to be used for any connection which does not fit in the other categories but is being displayed anyway.
		/// </summary>
		///<remarks>
		/// <para>???? &lt;class&gt; [&lt;client IP address in dot form&gt;]</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		TRACEUNKNOWN = 203,
		/// <summary>
		/// The RPL_TRACE* are all returned by the server in response to the TRACE message.  How many are returned is dependent on the the TRACE message and whether it was sent by an operator or not.  There is no predefined order for which occurs first. Replies RPL_TRACEUNKNOWN, RPL_TRACECONNECTING and RPL_TRACEHANDSHAKE are all used for connections which have not been fully established and are either unknown, still attempting to connect or in the process of completing the &#39;server handshake&#39;. RPL_TRACELINK is sent by any server which handles a TRACE message and has to pass it on to another server.  The list of RPL_TRACELINKs sent in response to a TRACE command traversing the IRC network should reflect the actual connectivity of the servers themselves along that path. RPL_TRACENEWTYPE is to be used for any connection which does not fit in the other categories but is being displayed anyway.
		/// </summary>
		///<remarks>
		/// <para>Oper &lt;class&gt; &lt;nick&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		TRACEOPERATOR = 204,
		/// <summary>
		/// The RPL_TRACE* are all returned by the server in response to the TRACE message.  How many are returned is dependent on the the TRACE message and whether it was sent by an operator or not.  There is no predefined order for which occurs first. Replies RPL_TRACEUNKNOWN, RPL_TRACECONNECTING and RPL_TRACEHANDSHAKE are all used for connections which have not been fully established and are either unknown, still attempting to connect or in the process of completing the &#39;server handshake&#39;. RPL_TRACELINK is sent by any server which handles a TRACE message and has to pass it on to another server.  The list of RPL_TRACELINKs sent in response to a TRACE command traversing the IRC network should reflect the actual connectivity of the servers themselves along that path. RPL_TRACENEWTYPE is to be used for any connection which does not fit in the other categories but is being displayed anyway.
		/// </summary>
		///<remarks>
		/// <para>User &lt;class&gt; &lt;nick&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		TRACEUSER = 205,
		/// <summary>
		/// The RPL_TRACE* are all returned by the server in response to the TRACE message.  How many are returned is dependent on the the TRACE message and whether it was sent by an operator or not.  There is no predefined order for which occurs first. Replies RPL_TRACEUNKNOWN, RPL_TRACECONNECTING and RPL_TRACEHANDSHAKE are all used for connections which have not been fully established and are either unknown, still attempting to connect or in the process of completing the &#39;server handshake&#39;. RPL_TRACELINK is sent by any server which handles a TRACE message and has to pass it on to another server.  The list of RPL_TRACELINKs sent in response to a TRACE command traversing the IRC network should reflect the actual connectivity of the servers themselves along that path. RPL_TRACENEWTYPE is to be used for any connection which does not fit in the other categories but is being displayed anyway.
		/// </summary>
		///<remarks>
		/// <para>Serv &lt;class&gt; &lt;int&gt;S &lt;int&gt;C &lt;server&gt; &lt;nick!user|*!*&gt;@&lt;host|server&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		TRACESERVER = 206,
		/// <summary>
		/// The RPL_TRACE* are all returned by the server in response to the TRACE message.  How many are returned is dependent on the the TRACE message and whether it was sent by an operator or not.  There is no predefined order for which occurs first. Replies RPL_TRACEUNKNOWN, RPL_TRACECONNECTING and RPL_TRACEHANDSHAKE are all used for connections which have not been fully established and are either unknown, still attempting to connect or in the process of completing the &#39;server handshake&#39;. RPL_TRACELINK is sent by any server which handles a TRACE message and has to pass it on to another server.  The list of RPL_TRACELINKs sent in response to a TRACE command traversing the IRC network should reflect the actual connectivity of the servers themselves along that path. RPL_TRACENEWTYPE is to be used for any connection which does not fit in the other categories but is being displayed anyway.
		/// </summary>
		///<remarks>
		/// <para>&lt;newtype&gt; 0 &lt;client name&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		TRACENEWTYPE = 208,
		/// <summary>
		/// The RPL_TRACE* are all returned by the server in response to the TRACE message.  How many are returned is dependent on the the TRACE message and whether it was sent by an operator or not.  There is no predefined order for which occurs first. Replies RPL_TRACEUNKNOWN, RPL_TRACECONNECTING and RPL_TRACEHANDSHAKE are all used for connections which have not been fully established and are either unknown, still attempting to connect or in the process of completing the &#39;server handshake&#39;. RPL_TRACELINK is sent by any server which handles a TRACE message and has to pass it on to another server.  The list of RPL_TRACELINKs sent in response to a TRACE command traversing the IRC network should reflect the actual connectivity of the servers themselves along that path. RPL_TRACENEWTYPE is to be used for any connection which does not fit in the other categories but is being displayed anyway.
		/// </summary>
		///<remarks>
		/// <para>File &lt;logfile&gt; &lt;debug level&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		TRACELOG = 261,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>&lt;linkname&gt; &lt;sendq&gt; &lt;sent messages&gt; &lt;sent bytes&gt; &lt;received messages&gt; &lt;received bytes&gt; &lt;time open&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		STATSLINKINFO = 211,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>&lt;command&gt; &lt;count&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		STATSCOMMANDS = 212,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>C &lt;host&gt; * &lt;name&gt; &lt;port&gt; &lt;class&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		STATSCLINE = 213,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>N &lt;host&gt; * &lt;name&gt; &lt;port&gt; &lt;class&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		STATSNLINE = 214,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>I &lt;host&gt; * &lt;host&gt; &lt;port&gt; &lt;class&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		STATSILINE = 215,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>K &lt;host&gt; * &lt;username&gt; &lt;port&gt; &lt;class&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		STATSKLINE = 216,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>Y &lt;class&gt; &lt;ping frequency&gt; &lt;connect frequency&gt; &lt;max sendq&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		STATSYLINE = 218,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>&lt;stats letter&gt; :End of /STATS report</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ENDOFSTATS = 219,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>L &lt;hostmask&gt; * &lt;servername&gt; &lt;maxdepth&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		STATSLLINE = 241,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>:Server Up %d days %d:%02d:%02d</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		STATSUPTIME = 242,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>O &lt;hostmask&gt; * &lt;name&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		STATSOLINE = 243,
		/// <summary>
		/// 
		/// </summary>
		///<remarks>
		/// <para>H &lt;hostmask&gt; * &lt;servername&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		STATSHLINE = 244,
		/// <summary>
		/// To answer a query about a client&#39;s own mode, RPL_UMODEIS is sent back.
		/// </summary>
		///<remarks>
		/// <para>&lt;user mode string&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		UMODEIS = 221,
		/// <summary>
		/// In processing an LUSERS message, the server sends a set of replies from RPL_LUSERCLIENT, RPL_LUSEROP, RPL_USERUNKNOWN, RPL_LUSERCHANNELS and RPL_LUSERME.  When replying, a server must send back RPL_LUSERCLIENT and RPL_LUSERME.  The other replies are only sent back if a non-zero count is found for them.
		/// </summary>
		///<remarks>
		/// <para>:There are &lt;integer&gt; users and &lt;integer&gt; invisible on &lt;integer&gt; servers</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		LUSERCLIENT = 251,
		/// <summary>
		/// In processing an LUSERS message, the server sends a set of replies from RPL_LUSERCLIENT, RPL_LUSEROP, RPL_USERUNKNOWN, RPL_LUSERCHANNELS and RPL_LUSERME.  When replying, a server must send back RPL_LUSERCLIENT and RPL_LUSERME.  The other replies are only sent back if a non-zero count is found for them.
		/// </summary>
		///<remarks>
		/// <para>&lt;integer&gt; :operator(s) online</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		LUSEROP = 252,
		/// <summary>
		/// In processing an LUSERS message, the server sends a set of replies from RPL_LUSERCLIENT, RPL_LUSEROP, RPL_USERUNKNOWN, RPL_LUSERCHANNELS and RPL_LUSERME.  When replying, a server must send back RPL_LUSERCLIENT and RPL_LUSERME.  The other replies are only sent back if a non-zero count is found for them.
		/// </summary>
		///<remarks>
		/// <para>&lt;integer&gt; :unknown connection(s)</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		LUSERUNKNOWN = 253,
		/// <summary>
		/// In processing an LUSERS message, the server sends a set of replies from RPL_LUSERCLIENT, RPL_LUSEROP, RPL_USERUNKNOWN, RPL_LUSERCHANNELS and RPL_LUSERME.  When replying, a server must send back RPL_LUSERCLIENT and RPL_LUSERME.  The other replies are only sent back if a non-zero count is found for them.
		/// </summary>
		///<remarks>
		/// <para>&lt;integer&gt; :channels formed</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		LUSERCHANNELS = 254,
		/// <summary>
		/// In processing an LUSERS message, the server sends a set of replies from RPL_LUSERCLIENT, RPL_LUSEROP, RPL_USERUNKNOWN, RPL_LUSERCHANNELS and RPL_LUSERME.  When replying, a server must send back RPL_LUSERCLIENT and RPL_LUSERME.  The other replies are only sent back if a non-zero count is found for them.
		/// </summary>
		///<remarks>
		/// <para>:I have &lt;integer&gt; clients and &lt;integer&gt; servers</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		LUSERME = 255,
		/// <summary>
		/// When replying to an ADMIN message, a server is expected to use replies RLP_ADMINME through to RPL_ADMINEMAIL and provide a text message with each.  For RPL_ADMINLOC1 a description of what city, state and country the server is in is expected, followed by details of the university and department (RPL_ADMINLOC2) and finally the administrative contact for the server (an email address here is required) in RPL_ADMINEMAIL.
		/// </summary>
		///<remarks>
		/// <para>&lt;server&gt; :Administrative info</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ADMINME = 256,
		/// <summary>
		/// When replying to an ADMIN message, a server is expected to use replies RLP_ADMINME through to RPL_ADMINEMAIL and provide a text message with each.  For RPL_ADMINLOC1 a description of what city, state and country the server is in is expected, followed by details of the university and department (RPL_ADMINLOC2) and finally the administrative contact for the server (an email address here is required) in RPL_ADMINEMAIL.
		/// </summary>
		///<remarks>
		/// <para>:&lt;admin info&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ADMINLOC1 = 257,
		/// <summary>
		/// When replying to an ADMIN message, a server is expected to use replies RLP_ADMINME through to RPL_ADMINEMAIL and provide a text message with each.  For RPL_ADMINLOC1 a description of what city, state and country the server is in is expected, followed by details of the university and department (RPL_ADMINLOC2) and finally the administrative contact for the server (an email address here is required) in RPL_ADMINEMAIL.
		/// </summary>
		///<remarks>
		/// <para>:&lt;admin info&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ADMINLOC2 = 258,
		/// <summary>
		/// When replying to an ADMIN message, a server is expected to use replies RLP_ADMINME through to RPL_ADMINEMAIL and provide a text message with each.  For RPL_ADMINLOC1 a description of what city, state and country the server is in is expected, followed by details of the university and department (RPL_ADMINLOC2) and finally the administrative contact for the server (an email address here is required) in RPL_ADMINEMAIL.
		/// </summary>
		///<remarks>
		/// <para>:&lt;admin info&gt;</para>
		/// <para>Can be invoked by:</para>
		///</remarks>
		ADMINEMAIL = 259,
	}
}