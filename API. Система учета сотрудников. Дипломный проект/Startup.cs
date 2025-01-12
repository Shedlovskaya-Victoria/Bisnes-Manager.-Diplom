using Microsoft.AspNetCore.Builder;
using BisnesManager.DatabasePersistens;
using Microsoft.Extensions.Configuration;
using System.Reflection;
//using BisnesManager.RequestsApp.Common.Mappings;
using AutoMapper;
using BisnesManager.DatabasePersistens.Context;

namespace BisnesManager.WebAPI.Diplom
{
    //public class Startup
    //{ 
    //    public IConfiguration Configuration { get; }
    //    public Startup(IConfiguration configuration) => Configuration = configuration;
    //    public void Configure(IServiceCollection services)
    //    {
    //        // во имя DI! даешь DI!
    //        var serviceProvider = services.BuildServiceProvider();
    //        try
    //        {
    //            var context = serviceProvider.GetRequiredService<BissnesExpertSystemDiplomaContext>();
    //            DBInitialazer.Initialize(context);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("!!!!!");
    //            //сюда еще вбросим ошибку... честно

    //        }

    //        services.AddAutoMapper(config =>
    //        {
    //            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    //            config.AddProfile(new AssemblyMappingProfile(typeof(BissnesExpertSystemDiplomaContext).Assembly));
    //        });

    //        services.AddDBPersistens(Configuration);

    //        services.AddCors(options =>
    //        {
    //            // cors позволяет ограничить доступ к нашему серверу, но для теста сделаем попростому и позволим стучаться всем.
    //            options.AddPolicy("AllowAll", policy =>
    //            {
    //                policy.AllowAnyHeader();
    //                policy.AllowAnyMethod();
    //                policy.AllowAnyOrigin();
    //            });
    //        });
    //    }
    //}
}
