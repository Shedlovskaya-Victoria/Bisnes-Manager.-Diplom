using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.Common.Behaviours;
using FluentValidation;
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
           // services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly() ); });
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>)); 
          // services.AddScoped<IPipelineBehavior<>>, ValidationBehaviour>(); 
            return services;
        }
    }
}
