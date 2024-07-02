using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Udemy.Core.Entities.Identity;
using Udemy.pl.Extention;
using Udemy.Repository.Data;
using Udemy.Repository.Data.SeedingData;

namespace Udemy.pl
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/
            builder.Services.AddDbContext<UdemyDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddIdentity<AppUser, IdentityRole>()
                             .AddEntityFrameworkStores<UdemyDbContext>();
            builder.Services.AddAplicationServices(builder.Configuration);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            #region SeedData
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var LoggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var userManger = services.GetRequiredService<UserManager<AppUser>>();
                var roleManger = services.GetRequiredService<RoleManager<IdentityRole>>();
                await SeedAdmin.CreateUser(userManger);
                await SeedRoles.AddRoles(roleManger);
            }
            catch (Exception ex)
            {
                var logger = LoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An Error Occurred IN program in Seeding DATA");
            } 
            #endregion
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();   
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}