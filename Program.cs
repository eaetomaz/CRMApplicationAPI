
using CRMApplicationAPI.Common;
using CRMApplicationAPI.Models;
using CRMApplicationAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes("sua-chave-secreta-super-segura")
                    )
                };
            });

            builder.Services.AddAuthorization();

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseRouting();
            app.UseAuthorization();
            
            app.MapControllers();
            app.MapRazorPages();

            app.Run();

        }
    }
}
