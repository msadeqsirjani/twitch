using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TwitchNightFall.Core.Application.Services;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Core.Application.ViewModels;
using TwitchNightFall.Core.Infra.Data;
using TwitchNightFall.Core.Infra.Data.Common;
using TwitchNightFall.Core.Infra.Data.Repository;
using TwitchNightFall.Core.Infra.IoC.MiddleWares;
using TwitchNightFall.Domain.Repository;
using TwitchNightFall.Domain.Repository.Common;

namespace TwitchNightFall.Core.Infra.IoC;

public static class DependencyContainer
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        var setting = new JwtSetting();

        configuration.Bind("JwtSetting", setting);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(setting.IssuerSigningKey)),
                ValidateIssuer = setting.ValidateIssuer,
                ValidIssuer = setting.ValidIssuer,
                ValidateAudience = setting.ValidateAudience,
                ValidAudience = setting.ValidAudience,
                RequireExpirationTime = setting.RequireExpirationTime,
                ValidateLifetime = setting.ValidateLifetime,
                ClockSkew = TimeSpan.FromDays(1)
            };
        });

        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IUnitOfWorkAsync, UnitOfWorkAsync>();
        services.AddTransient(typeof(IService<>), typeof(Service<>));
        services.AddTransient(typeof(IServiceAsync<>), typeof(ServiceAsync<>));
        services.AddTransient<ILogService, LogService>();
        services.AddTransient<ITwitchRepository, TwitchRepository>();
        services.AddTransient<IForgivenessRepository, ForgivenessRepository>();
        services.AddTransient<ITwitchService, TwitchService>();
        services.AddTransient<IForgivenessService, ForgivenessService>();
        services.AddTransient<IAdministratorRepository, AdministratorRepository>();
        services.AddTransient<IAdministratorService, AdministratorService>();
        services.AddTransient<IJwtService, JwtService>();

        services.Configure<TwitchSetting>(configuration.GetSection("TwitchSetting"));
        services.Configure<JwtSetting>(configuration.GetSection("JwtSetting"));

        services.AddHttpClient();

        services.AddCors(options => options.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build()));
        
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("docs", new OpenApiInfo
            {
                Title = "Twitch Night Fall API",
                Version = "v1"
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer xxx'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                }
            });

            const string xmlFile = "TwitchNightFall.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });
    }

    public static void UseApplications(this WebApplication application)
    {
        application.UseMiddleware<ExceptionHandler>();
        application.UseSwagger();
        application.UseSwaggerUI(options =>
        {
            options.DocumentTitle = "Twitch Night Fall API Documentation";
            options.SwaggerEndpoint("/swagger/docs/swagger.json", "Twitch Night Fall API");
            options.RoutePrefix = "docs";
        });
        application.UseCors("CorsPolicy");
        application.UseAuthorization();
        application.UseAuthentication();
        application.MapControllers();
    }
}