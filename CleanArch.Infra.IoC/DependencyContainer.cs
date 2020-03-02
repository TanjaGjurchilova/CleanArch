using Microsoft.Extensions.DependencyInjection;
using CleanArch.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.IoC
{
   public  class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer
            services.AddScoped<IUserService, UseService>();

        }
    }
}
