using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Soccer.BusinessLayer.Abstract;
using Soccer.BusinessLayer.Concrete;
using Soccer.DataAccessLayer.Abstract;
using Soccer.DataAccessLayer.Concrete;
using Soccer.DataAccessLayer.EntityFramework;

namespace Soccet.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddDbContext<Context>();

            builder.Services.AddScoped<ITeamDal, EFTeamDal>();
            builder.Services.AddScoped<ITeamService, TeamManager>();

            builder.Services.AddScoped<IPlayerDal, EFPlayerDal>();
            builder.Services.AddScoped<IPlayerService, PlayerManager>();

            builder.Services.AddAutoMapper(typeof(Program));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Team}/{action=Default}/{id?}");

            app.Run();
        }
    }
}