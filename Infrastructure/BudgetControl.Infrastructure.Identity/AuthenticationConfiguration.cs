using BudgetControl.Infrastructure.Identity.Authentication;
using BudgetControl.Infrastructure.Identity.Authentication.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetControl.Infrastructure.Identity
{
    public static class AuthenticationConfiguration
    {
        public static readonly string Secret = "9055E851BA9F473B9650C8FB6B5055BC";

        public static void AddAuthenticationConfiguration(this IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSingleton<ITokenService, JwtTokenService>();
        }
    }
}
