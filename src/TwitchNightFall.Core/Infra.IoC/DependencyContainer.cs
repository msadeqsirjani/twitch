using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TwitchNightFall.Common.Common;
using TwitchNightFall.Common.Exceptions;
using TwitchNightFall.Core.Application.Extensions;
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
        services.AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var result = context.ModelState.Values.SelectMany(x => x.Errors).First().ErrorMessage;

                    return new UnprocessableEntityObjectResult(Result.WithException(result));
                };
            })
            .AddFluentValidation(options => options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()))
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        services.AddOptions();
        services.AddMemoryCache();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

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
        services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();
        services.AddTransient<ISubscriptionService, SubscriptionService>();
        services.AddTransient<IPlanRepository, PlanRepository>();
        services.AddTransient<IPlanService, PlanService>();
        services.AddTransient<ITransactionRepository, TransactionRepository>();
        services.AddTransient<ITransactionService, TransactionService>();
        services.AddTransient<ITransactionVerificationService, TransactionVerificationService>();
        services.AddTransient<IJwtService, JwtService>();
        services.AddTransient<IFileService, FileService>();

        services.Configure<TwitchSetting>(configuration.GetSection("TwitchSetting"));
        services.Configure<JwtSetting>(configuration.GetSection("JwtSetting"));

        services.AddHttpClient();

        services.AddCors(options => options.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build()));

        services.AddEndpointsApiExplorer();

        var setting = new JwtSetting();

        configuration.Bind("JwtSetting", setting);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
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

                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        try
                        {
                            var token = context.HttpContext.GetAuthenticationToken();

                            var handler = new JwtSecurityTokenHandler();

                            handler.ValidateToken(token, options.TokenValidationParameters, out _);

                            return Task.CompletedTask;
                        }
                        catch
                        {
                            throw new UnAuthorizedException(Statement.UnAuthorized);
                        }
                    }
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy(JwtService.Administrator, builder => builder.RequireAssertion(context => context.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value == JwtService.Administrator));
            options.AddPolicy(JwtService.Other, builder => builder.RequireAssertion(context => context.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value == JwtService.Other));
        });

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
        application.UseAuthentication();
        application.UseAuthorization();
        application.MapControllers();
    }
}