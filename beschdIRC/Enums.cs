using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beschdIRC {
	/// <summary>
	/// siehe http://tools.ietf.org/html/rfc1459.html#section-6.1
	/// </summary>
	public enum ErrorCodes {
		None = 0,

		NoSuchNick = 401, // so einen Nick gibt es nicht.
		NoSuchServer = 402, // so einen Server gibt es nicht.
		NoSuchChannel = 403, // so einen channel gibt es nicht.
		CannotSendToChan = 404, // du kannst nicht in diesen Channel senden
		TooManychannels = 405, // du bist in zuvielen Channeln
		WasNoSuchNick = 406,
		TooManytargets = 407, // du hast jemanden doppelt angegeben
		NoOrigin = 409, // keine Quelle

		NoRecipient = 411, // kein Empfänger
		NoTextToSend = 412, // kann nichts senden
		NoTopLevel = 413, // domain ist nicht domain.tld
		WildTopLevel = 414, // domain ist *.domain.tld

		UnknownCommand = 421, // unbekannter Command
		NoMotd = 422, // kein MOTD
		NoAdminInfo = 423, // keine AdminInfo
		FileError = 424, // kann eine Datei nicht lesen

		NoNicknameGiven = 431, // du hast keinen Nick angegeben
		ErroneusNickname = 432, // der Nickname kollidiert mit den Namensregeln
		NicknameInUse = 433, // der Name ist bereits in benutzung
		NickCollision = 436, // der Nick kollidiert auf einem anderen Server

		UserNotInChannel = 441, // der User ist nicht da.
		NotOnChannel = 442, // du bist nicht in einem Channel
		UserOnChannel = 443, // du bist in diesem Channel
		NoLogin = 444, // log dich ein, Idiot
		SummonDisabled = 445, // du darfst niemanden inviten
		UsersDisabled = 446, // du kannst die dir Liste nicht anschauen

		NotRegistered = 451, // registrieren oder hier passiert nichts

		NeedMoreParams = 461, // du hast zu wenig angegeben, ICH WILL MEHR!
		AlreadyRegistered = 462, // lern deine Commands auswendig
		NoPermForHost = 463, // du bist zu dumm
		PasswDismatch = 464, // wo hast du dein Passwort geschrieben?
		YoureBannedCreep = 465, // es gibt einen Grund, warum du hier nicht mehr raufkommst
		Keyset = 467, // und nein.

		ChannelIsFull = 471, // wirf jemanden raus, bevor du reingehen kannst
		UnknownMode = 472, // wat?
		InviteOnlyChan = 473, // nope. Nur mit Einladung
		BannedFromChan = 474, // du bist gebannt.
		BadChannelKey = 475, // das gibts schon.

		NoPrivileges = 481, // komm wieder, wenne weißt, warum du das nicht darfst
		ChanOpPrivsNeeded = 482, // nein. Du bist nicht ich
		CantKillServer = 483, // hättest du wohl gerne

		NoOperHost = 491, // kein Oper, Depp!

		UModeUnknownFlag = 501, // irgendwas unbekanntes
		UsersDontMatch = 502 // da passt was nicht
	}

	/// <summary>
	/// siehe http://tools.ietf.org/html/rfc1459.html#section-6.2
	/// </summary>
	public enum ReplyCodes {
		None = 300,

		/// <summary>
		/// <para>everyone (except channels) who PRIVMSGs connection</para>
		/// <para>&lt;nick&gt; :&lt;message&gt;</para>
		/// </summary>
		/// <remarks>
		/// <para>These replies are used with the AWAY command (if allowed).  AWAY is sent to any client sending a PRIVMSG to a client which is away.  AWAY is only sent by the server to which the client is connected. Replies UNAWAY and NOWAWAY are sent when the client removes and sets an AWAY message.</para>
		/// <para>Issued by AWAY command</para>
		/// <para>Results:
		/// <para>Reply.Unaway</para>
		/// <para>Reply.NowAway</para>
		/// </para>
		/// </remarks>
		Away = 301,

		/// <summary>
		/// <para>current connection</para>
		/// <para>Reply = &lt;nickname&gt; (Operator ? * : '') = (away ? + : -)&lt;hostname&gt;</para>
		/// <para>[reply]+</para>
		/// </summary>
		/// <remarks>
		/// <para>Issued by USERHOST &lt;nickname&gt;+</para>
		/// <para>
		/// Return values:
		/// <para>Reply.UserHost</para>
		/// <para>Error.NeedMoreParams</para>
		/// </para>
		/// </remarks>
		Userhost = 302,

		/// <summary>
		/// <para>current connection</para>
		/// <para>&lt;nickname&gt;[ &lt;nickname&gt;]+</para>
		/// </summary>
		/// <remarks>
		/// <para>Issued by ISON &lt;nickname&gt;+</para>
		/// </remarks>
		IsOn = 303,

		/// <summary>
		/// <para>current connection</para>
		/// <para>:You are no longer marked as being away</para>
		/// </summary>
		/// <remarks>
		/// <para>Reply format used by USERHOST to list replies to the query list.  The reply string is composed as follows:</para>
		/// <para>The '*' indicates whether the client has registered as an Operator.  The '-' or '+' characters represent whether the client has set an AWAY message or not respectively.</para>
		/// <para>Issued by AWAY</para>
		/// </remarks>
		Unaway = 305,

		/// <summary>
		/// <para>current connection</para>
		/// <para>:You have been marked as being away</para>
		/// </summary>
		/// <remarks>
		/// <para>These replies are used with the AWAY command (if allowed).  AWAY is sent to any client sending a PRIVMSG to a client which is away.  AWAY is only sent by the server to which the client is connected. Replies UNAWAY and NOWAWAY are sent when the client removes and sets an AWAY message.</para>
		/// <para>Issued by AWAY :&lt;message&gt;</para>
		/// </remarks>
		NowAway = 306,

		/// <summary>
		/// <para>current connection</para>
		/// <para>&lt;nickname&gt; &lt;username&gt; &lt;hostname&gt; * :&lt;realname&gt;</para>
		/// </summary>
		/// <remarks>
		/// <para>Issued by /WHOIS &lt;nickname&gt;+</para>
		/// </remarks>
		WhoIsUser = 311,

		/// <summary>
		/// <para>current connection</para>
		/// <para>&lt;nickname&gt; &lt;servername&gt; :&lt;serverinfo&gt;</para>
		/// </summary>
		WhoIsServer = 312,
		/// <summary>
		/// <para>current connection</para>
		/// <para>&lt;nickname&gt; :is an IRC operator</para>
		/// </summary>
		WhoIsOperator = 313,

		/// <summary>
		/// &lt;nickname&gt; &lt;username&gt; &lt;host&gt; * :&lt;realname&gt;
		/// </summary>
		WhoWasUser = 314,

		/// <summary>
		/// <para>current connection</para>
		/// <para>&lt;nickname&gt; &lt;integer&gt; :seconds idle</para>
		/// </summary>
		WhoIsIdle = 317,

		/// <summary>
		/// <para>current connection</para>
		/// <para>&lt;nickname&gt; :End of /WHOIS list</para>
		/// </summary>
		EndOfWhois = 318,

		/// <summary>
		/// <para>"&lt;nickname&gt; :{[@|+]&lt;channel&gt;}"</para>
		/// </summary>
		WhoIsChannels = 319,

		/// <summary>
		/// &lt;nickname&gt; :End of WHOWAS
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		EndOfWhoWas = 368,
	}
}
