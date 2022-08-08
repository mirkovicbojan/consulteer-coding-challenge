using System.Text;
using MainAPI.Authorization;
using MainAPI.Context;
using MainAPI.Contracts;
using MainAPI.Handlers;
using MainAPI.Middlewares;
using MainAPI.Repository;
using MainAPI.Repository.Interfaces;
using MainAPI.Services;
using MainAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Adding the Authorize Button to Swagger
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "ConsulteerCodeTaskAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
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

builder.Services.AddDbContext<AppDbContext>(
    o => o.UseSqlite(builder.Configuration.GetConnectionString("Default Connection"))
        .UseLazyLoadingProxies()
);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddSingleton<IAuthorizationHandler, CanViewAllUsersHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, CanEditRolesHandler>();
builder.Services.AddHttpContextAccessor();

//Global Exception Handler
builder.Services.AddSingleton<ILoggerManager, LoggerService>();
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

//JWT Authentication Service
var key = Encoding.ASCII.GetBytes(configuration["JWT:Key"]);

builder.Services.AddAuthentication(a =>
{
    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(b =>
{
    b.RequireHttpsMetadata = false;
    b.SaveToken = true;
    b.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddSingleton<AuthenticationService>(new AuthenticationService(key));

//Policy Based Authorization
builder.Services.AddAuthorization(options => 
{
    options.AddPolicy("canViewAllUsers", policy => policy.AddRequirements(
        new CanViewAllUsersRequirement()
    ));
    options.AddPolicy("isAdmin", policy => policy.AddRequirements(
        new IsAdminRequirement()
    ));
});
//

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Activating the Custom Exception Middleware
app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
