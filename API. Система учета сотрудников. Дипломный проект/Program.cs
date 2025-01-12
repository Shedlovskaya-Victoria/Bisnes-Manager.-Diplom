using BisnesManager.DatabasePersistens;
using BisnesManager.DatabasePersistens.Context;
//using BisnesManager.RequestsApp.Common.Mappings; //   �� ������� ���
using BisnesManager.WebAPI.Diplom.Middleware;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
//using BisnesManager.RequestsApp; //   �� ������� ���
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddRequestApp(); //   �� ������� ���

builder.Services.AddDbContext<BissnesExpertSystemDiplomaContext>( options=>{            // �� ������������
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
BisnesManager.DatabasePersistens.DBInitialazer.Initialize();

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
