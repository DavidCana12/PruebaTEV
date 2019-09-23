using Castle.Core.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTEV.Implementation
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterProjectCoreCoreLogicServices(this IServiceCollection services)
        {
            services.AddTransient<IUserManager, UserManager>();

            return services;
        } 
    }
}
