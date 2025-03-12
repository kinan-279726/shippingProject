using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.Contracts;
using DataAccess.Repositorys;
using Serilog;
using BusinessLayer.Services;
using BusinessLayer.Contracts;
using BusinessLayer.Mapping;
using UIProject;
internal class Program
{
    //[Obsolete]
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Register All services 
        RegisterServices.serv(builder);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            _ = endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{Area:exists}/{Controller=Home}/{action=Index}/{id?}");
            _ = endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
        });
        app.Run();
    }
}