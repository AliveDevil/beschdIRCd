using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beschdIRC.Models.Database
{
	class DatabaseContext : DbContext
	{
		public DbSet<ChannelModel> Channels { get; set; }
		public DbSet<ChannelUserModel> ChannelUser { get; set; }
		public DbSet<UserModel> User { get; set; }
	}
}
