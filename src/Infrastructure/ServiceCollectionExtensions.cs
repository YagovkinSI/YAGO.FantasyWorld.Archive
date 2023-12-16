using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YAGO.FantasyWorld.Infrastructure.Database;
using YAGO.FantasyWorld.Infrastructure.Identity;

namespace YAGO.FantasyWorld.Infrastructure
{
	public static partial class ServiceCollectionExtensions
	{
		public static IServiceCollection AddInfrastructure(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			services
				.AddDatabase(configuration)
				.AddIdentity();

			return services;
		}
	}
}
