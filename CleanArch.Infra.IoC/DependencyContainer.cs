using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Repository;

namespace CleanArch.Infra.IoC 
{
   public  class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer
            services.AddScoped<IUserService, UserService>();

            //Data Layer
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
