using Ecom.Api.Middelwars;
using Ecom.infrastructure;
namespace Ecom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            // Add services to the container.
            builder.Services.AddMemoryCache();
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();


            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.InfrastructureCinfigration(builder.Configuration);
            // builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.MapOpenApi();
            //}
            // Swagger
            app.UseCors("AllowAngular");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseMiddleware<midelwarExptions>();

            app.UseStatusCodePagesWithReExecute("/error/{0}");
            
            app.UseHttpsRedirection();

            app.UseAuthorization();



            app.MapControllers();

            app.Run();
        }
    }
}
