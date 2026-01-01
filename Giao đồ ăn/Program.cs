
using FoodDeliveryAPI.DAL;
using Giao_đồ_ăn.BLL;
using Giao_đồ_ăn.Models;

namespace Giao_đồ_ăn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ShipperDAL>();
            builder.Services.AddScoped<bll_Shipper>();
            builder.Services.AddScoped<RestaurantDAL>();
            builder.Services.AddScoped<bll_Restaurant>();
            builder.Services.AddScoped<UserDAL>();
            builder.Services.AddScoped<bll_User>();
                


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
