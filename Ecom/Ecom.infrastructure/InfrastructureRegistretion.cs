using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ecom.core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Ecom.infrastructure.Repositires;
using Microsoft.EntityFrameworkCore;
using Ecom.infrastructure.Data;

namespace Ecom.infrastructure
{
    public static class InfrastructureRegistretion
    {
        public static IServiceCollection InfrastructureCinfigration(this IServiceCollection services , IConfiguration configuration)
        {
            //services.AddTransient   // send dont save any thing
            //services.AddScoped      // save to limited time like http request
            //services.AddSingleton   // thing run one time to all application

            // spakety code for each repository

            //services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            //services.AddScoped(typeof(IProductRepository), typeof(IProductRepository));
            //services.AddScoped(typeof(IPhotoRepository), typeof(IPhotoRepository));

            services.AddScoped(typeof(IGeniricRepositire<>), typeof(GeniricRepositire<>));

            // unit work 

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            // aply Dbcontext

            services.AddDbContext<AppDbContext>((DbContextOptionsBuilder op) =>
            {
                op.UseSqlServer(configuration.GetConnectionString("Ecom"));
            });

            return services;
        }
    }
}
