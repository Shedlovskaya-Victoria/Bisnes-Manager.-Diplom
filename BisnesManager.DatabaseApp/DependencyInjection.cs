using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using BisnesManager.Database.Context;

namespace BisnesManager.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDBPersistens(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<BissnesExpertSystemDiplomaContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<BissnesExpertSystemDiplomaContext>(provider => provider.GetService<BissnesExpertSystemDiplomaContext>());
            return services;
        }
    }
}
