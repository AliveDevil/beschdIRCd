using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beschdIRC {
	/// <summary>
	/// see http://tools.ietf.org/html/rfc1459.html#section-6.2
	/// </summary>
	public enum ReplyCodes {
		/// <summary>
		/// Just a dummy.
		/// </summary>
		None = 300,

		#region Away
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
		#endregion
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
		EndOfWhoWas = 369,
	}
}
