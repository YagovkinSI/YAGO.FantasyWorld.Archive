using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YAGO.FantasyWorld.Infrastructure.Database.Models;

namespace YAGO.FantasyWorld.Infrastructure.Database
{
	public partial class DatabaseContext : IdentityDbContext<User>
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			   : base(options)
		{
			Database.Migrate();
		}
	}
}
