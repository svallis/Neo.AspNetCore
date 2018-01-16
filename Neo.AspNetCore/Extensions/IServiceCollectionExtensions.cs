using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Neo.AspNetCore
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Add the Neo services and configuration to the application service collection
        /// </summary>
        /// <param name="services">The services collection</param>
        /// <param name="config">The system configuration interface</param>
        public static void AddNeo(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<INeoService, NeoService>();
            services.Configure<NeoServiceOptions>(config.GetSection("Neo"));
        }
    }
}
