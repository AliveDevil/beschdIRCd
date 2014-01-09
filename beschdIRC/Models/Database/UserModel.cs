using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace beschdIRC.Models.Database
{
	[Table("User")]
	public class UserModel
	{
		[Key]
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string LoginName { get; set; }
		public string Password { get; set; }

		public virtual IEnumerable<ChannelUserModel> ChannelProperties { get; set; }
	}
}
