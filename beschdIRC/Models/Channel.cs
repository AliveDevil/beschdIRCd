using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beschdIRC.Models {
	public class Channel {
		public string Name {
			get;
			set;
		}
		public bool InviteOnly {
			get;
			set;
		}
		public bool Moderated {
			get;
			set;
		}
		public bool Invisible {
			get;
			set;
		}
		public string Password {
			get;
			set;
		}
		public string Topic {
			get;
			set;
		}
		public string Connect {
			get;
			set;
		}
	}
}
