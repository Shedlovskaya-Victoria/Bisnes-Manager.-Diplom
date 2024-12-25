using BisnesManager.DatabasePersistens.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.DatabasePersistens
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDBPersistens(IServiceCollection services, IConfiguration configuration)
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
