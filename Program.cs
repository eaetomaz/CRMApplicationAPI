
using CRMApplicationAPI.Common;
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

            builder.Services.AddScoped(typeof(IBaseService<>), typeof(IBaseService<>));
            builder.Services.AddScoped<ClientService, ClientService>();

            var app = builder.Build();
            
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();

        }
    }
}
