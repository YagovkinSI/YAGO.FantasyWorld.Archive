using Microsoft.AspNetCore.Identity;
using System;

namespace YAGO.FantasyWorld.Infrastructure.Database.Models
{
	public class User : IdentityUser
	{
		public DateTimeOffset Registration { get; set; }
		public DateTimeOffset LastActivity { get; set; }
	}
}
