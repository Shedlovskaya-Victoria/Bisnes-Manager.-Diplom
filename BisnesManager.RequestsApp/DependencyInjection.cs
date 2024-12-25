using BisnesManager.DatabasePersistens.Model;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRequestApp(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
