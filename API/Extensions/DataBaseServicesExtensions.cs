using Core.Entities.Identity;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class DataBaseServicesExtensions
    {
        public static IServiceCollection AddDataBaseServices(this IServiceCollection services, IConfiguration _config)
        {
            services.AddDbContext<StoreContext>(x =>
               x.UseSqlServer(_config.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<AppIdentityDbContext>(x =>
            //{
            //    x.UseSqlServer(_config.GetConnectionString("IdentityConnection"));
            //});

            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(_config.GetConnectionString("IdentityConnection")));

            return services;
        }

        public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration _config)
        {
            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var configuration = ConfigurationOptions.Parse(_config.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuration);
            });
            return services;
        }

        public static IServiceCollection AddIdentityServices (this IServiceCollection services, IConfiguration _configuration)
        {
            var builder = services.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

                .AddJwtBearer(o=> {
                
                   
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"])),
                        ValidIssuer = _configuration["Token:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience=false
                    };
                });

            return services;
        }
    }
}
