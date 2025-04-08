
using CRMApplicationAPI.Common;
using CRMApplicationAPI.Models;
using CRMApplicationAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace CRMApplicationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseFirebird(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddRazorPages();
            
            builder.Services.AddScoped<IBaseService<Clientes>, ClientService>();
            builder.Services.AddScoped<ClientService>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();            

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseAuthorization();
            
            app.MapControllers();
            app.MapRazorPages();

            app.Run();

        }
    }
}
