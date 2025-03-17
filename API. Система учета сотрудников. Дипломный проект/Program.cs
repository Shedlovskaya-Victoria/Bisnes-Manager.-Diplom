using BisnesManager.Database;
using BisnesManager.WebAPI.Diplom.Middleware;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using BisnesManager.Database.Context;
using BisnesManager.Database.Model;
using BisnesManager.Database.Interfaces;
using BisnesManager.Database.Repositories;
using BisnesManager.ETL.Repositories;
using BisnesManager.ETL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => 
        { 
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; 
        } 
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<BissnesExpertSystemDiploma7Context>(options =>
{            // ¡ƒ œŒƒÀ Àﬁ◊≈Õ»≈
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
///BisnesManager.Database.DBInitialazer.Initialize();
builder.Services.AddScoped<PlanRepository>();
builder.Services.AddScoped<RoleRepository>();
builder.Services.AddScoped<StatisticRepository>();
builder.Services.AddScoped<StatusRepository>();
builder.Services.AddScoped<TaskRepository>();
builder.Services.AddScoped<UserRepository>();

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
