
using Goodsmart_Repository;
using Goodsmart_Repository._1_IRepositories;
using Goodsmart_Repository._2_Repositories;
using Goodsmart_Service.IServices;
using Goodsmart_Service.Services;
using Microsoft.EntityFrameworkCore;

namespace Goodsmart_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            //--------------------------  Add services to the container -----------------------

            // Connection String service
            builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(
                       builder.Configuration.GetConnectionString("DefaultConnection1"), b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                )
            );

            //Cors services
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200") // Add your Angular app's URL here
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            // Dependency Injection sevices
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();


            //Controller Service
            builder.Services.AddControllers();

            //--------------------------------------------------------------------------------------



            //Swagger/OpenAPI 
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowSpecificOrigin");


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}