﻿
using CleanArchitecture.Application.Interfaces.Authentication;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Application.Services.Authentication;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            ConfigurationManager configuration)
        {
            //services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));


            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}
