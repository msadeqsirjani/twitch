using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TwitchNightFall.Core.Application.Services;
using TwitchNightFall.Core.Application.Services.Common;
using TwitchNightFall.Core.Application.Validators;
using TwitchNightFall.Core.Application.ViewModels;
using TwitchNightFall.Core.Application.ViewModels.FollowerAward;
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
        services.AddControllers().AddFluentValidation();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IUnitOfWorkAsync, UnitOfWorkAsync>();
        services.AddTransient(typeof(IService<>), typeof(Service<>));
        services.AddTransient(typeof(IServiceAsync<>), typeof(ServiceAsync<>));
        services.AddTransient<ILogService, LogService>();
        services.AddTransient<ITwitchAccountRepository, TwitchAccountRepository>();
        services.AddTransient<IFollowerAwardRepository, FollowerAwardRepository>();
        services.AddTransient<ITwitchAccountService, TwitchAccountService>();
        services.AddTransient<IFollowerAwardService, FollowerAwardService>();
        services.AddTransient<ITwitchHelixService, TwitchHelixService>();
        services.AddTransient<IValidator<FollowerAwardAddDto>, FollowerAwardAddDtoValidator>();

        services.Configure<TwitchSetting>(configuration.GetSection("TwitchSetting"));

        services.AddHttpClient();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddCors(options =>
            options.AddPolicy("CorsPolicy", config => config.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .Build()));
        
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

    public static void UseApplications(this WebApplication application, IWebHostEnvironment environment)
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
        application.MapControllers();
    }
}