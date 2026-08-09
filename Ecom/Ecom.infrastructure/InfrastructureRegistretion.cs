using Ecom.core.Interfaces;
using Ecom.core.Services;
using Ecom.infrastructure.Data;
using Ecom.infrastructure.Repositires;
using Ecom.infrastructure.Repositires.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

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

            // connection redis

            services.AddSingleton<IConnectionMultiplexer>(i =>
            {
                var config = ConfigurationOptions.Parse(configuration.GetConnectionString("Redis"));
                return ConnectionMultiplexer.Connect(config);
                   
            });

            services.AddSingleton<IImageManagerService, ImageManagerService>();
            services.AddSingleton < IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot")));
            // aply Dbcontext

            services.AddDbContext<AppDbContext>((DbContextOptionsBuilder op) =>
            {
                op.UseSqlServer(configuration.GetConnectionString("Ecom"));
            });

            return services;
        }
    }
}
