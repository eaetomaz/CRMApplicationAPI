
using CRMApplicationAPI.Common;
using Microsoft.EntityFrameworkCore;

namespace CRMApplicationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();

            // Adicionar conexão com Firebird
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseFirebird(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();

        }
    }
}
