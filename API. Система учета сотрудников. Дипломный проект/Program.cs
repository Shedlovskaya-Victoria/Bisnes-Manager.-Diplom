using BisnesManager.Database;
using BisnesManager.WebAPI.Diplom.Middleware;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

using BisnesManager.Database.Models;
using BisnesManager.Database.Interfaces;
using BisnesManager.Database.Repositories;
using BisnesManager.ETL.Repositories;
using BisnesManager.ETL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using BisnesManager.ETL.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => 
        { 
            options.JsonSerializerOptions.PropertyNamingPolicy = null;  //json
        } 
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey( 
            System.Text.Encoding.UTF8.GetBytes( builder.Configuration["JWT:SigningKey"]) 
        ),
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" }); //customize swager for use jwt token
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddDbContext<BissnesExpertSystemDiploma7Context>(options =>                   //db context
{            // ¡ƒ œŒƒÀ Àﬁ◊≈Õ»≈
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

///BisnesManager.Database.DBInitialazer.Initialize();
builder.Services.AddScoped<PlanRepository>();                           //repositories
builder.Services.AddScoped<RoleRepository>();
builder.Services.AddScoped<StatisticRepository>();
builder.Services.AddScoped<StatusRepository>();
builder.Services.AddScoped<TaskRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<AuthRepository>();

builder.Services.AddScoped<TokenServices>();
builder.Services.AddScoped<IPasswordHasher<IdentityUser>, PasswordHasher<IdentityUser>>();               //password hasher

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {        //check verify passsword 
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<BissnesExpertSystemDiploma7Context>();

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

//app.UseCors("AllowAll"); //

app.UseAuthentication(); // for jwt and identity
app.UseAuthorization();
app.MapControllers();
app.Run();
