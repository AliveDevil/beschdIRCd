using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beschdIRC.Models.Database {
	[Table("ChannelUser")]
	public class ChannelUserModel {
		[Key]
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		public int Id {
			get;
			set;
		}
		public UserModel User {
			get;
			set;
		}
		public ChannelModel Channel {
			get;
			set;
		}
		public bool Owner {
			get;
			set;
		}
		public bool CanRead {
			get;
			set;
		}
		public bool CanWrite {
			get;
			set;
		}
		public bool CanJoin {
			get;
			set;
		}
		public bool CanKick {
			get;
			set;
		}
		public bool CanInvite {
			get;
			set;
		}
		public bool CanTopic {
			get;
			set;
		}
	}
}
