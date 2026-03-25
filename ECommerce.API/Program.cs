using ECommerce.Application.MappingProfile;
// Replace this line:
// builder.Services.AddAutoMapper(typeof(MappingProfile));

// With this line:
using ECommerce.Application.Services; 
using ECommerce.Domain.Repositories;
using ECommerce.Domain.Services; 
using ECommerce.Infrastructure.Persistence;
using ECommerce.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore; 

namespace ECommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options => 
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnections")));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IOrderRespository, OrderRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<OrderDomainService>();
            builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile)); 
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
