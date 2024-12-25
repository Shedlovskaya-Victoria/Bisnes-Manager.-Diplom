using Microsoft.AspNetCore.Builder;
using BisnesManager.DatabasePersistens;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using BisnesManager.RequestsApp.Common.Mappings;
using BisnesManager.DatabasePersistens;
using AutoMapper;
using BisnesManager.DatabasePersistens.Context;

namespace BisnesManager.WebAPI.Diplom
{
    public class Startup
    { 
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureService(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(BissnesExpertSystemDiplomaContext).Assembly));
            });

            services.AddDBPersistens(Configuration);

            services.AddCors(options =>
            {
                // cors позволяет ограничить доступ к нашему серверу, но для теста сделаем попростому и позволим стучаться всем.
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
        }
    }
}
