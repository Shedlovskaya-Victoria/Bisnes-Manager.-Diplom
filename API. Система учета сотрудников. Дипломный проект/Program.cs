using BisnesManager.DatabasePersistens;
using BisnesManager.DatabasePersistens.Context;
using BisnesManager.RequestsApp.Common.Mappings;
using BisnesManager.WebAPI.Diplom.Middleware;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BisnesManager.RequestsApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRequestApp();

    // во имя DI! даешь DI!
    //var serviceProvider = builder.Services.BuildServiceProvider();
    //try
    //{
    //    var context = serviceProvider.GetRequiredService<BissnesExpertSystemDiplomaContext>();
    //    DBInitialazer.Initialize(context);
    //} 
    //catch (Exception ex)
    //{
    //    //сюда еще вбросим ошибку... честно
        
    //}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionMiddlewareExtensions();      //

app.UseRouting();     //

app.UseHttpsRedirection();

app.UseCors("AllowAll"); //

app.UseAuthorization();

app.MapControllers();

app.Run();
