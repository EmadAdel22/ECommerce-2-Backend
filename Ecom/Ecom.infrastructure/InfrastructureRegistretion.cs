using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ecom.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Ecom.infrastructure.Repositires;

namespace Ecom.infrastructure
{
    public static class InfrastructureRegistretion
    {
        public static IServiceCollection InfrastructureCinfigration(this IServiceCollection services)
        {
            //services.AddTransient   // send dont save any thing
            //services.AddScoped      // save to limited time like http request
            //services.AddSingleton   // thing run one time to all application

            services.AddScoped(typeof(IGeniricRepositire<>), typeof(GeniricRepositire<>));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(IProducRepository), typeof(IProducRepository));
            services.AddScoped(typeof(IPhotoReposatory), typeof(IPhotoReposatory));
            
            return services;
        }
    }
}
