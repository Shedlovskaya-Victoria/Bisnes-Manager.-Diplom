using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using BisnesManager.Database.Models;

namespace BisnesManager.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDBPersistens(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<BissnesExpertSystemDiploma7Context>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<BissnesExpertSystemDiploma7Context>(provider => provider.GetService<BissnesExpertSystemDiploma7Context>());
            return services;
        }
    }
}
