using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beschdIRC.Models.Database
{
	[Table("Channel")]
	public class ChannelModel
	{
		[Key]
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public bool InviteOnly { get; set; }
		public bool Moderated { get; set; }
		public bool Invisible { get; set; }
		public string Password { get; set; }
		public string Topic { get; set; }
		public string Connect { get; set; }

		public virtual IEnumerable<ChannelUserModel> UserInformation { get; set; }
	}
}
