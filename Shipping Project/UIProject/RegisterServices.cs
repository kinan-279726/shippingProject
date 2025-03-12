using BusinessLayer.Contracts;
using BusinessLayer.Mapping;
using BusinessLayer.Services;
using DataAccess.Contracts;
using DataAccess.Repositorys;
using DataAccess;
using Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace UIProject;

public static class RegisterServices
{
    public static void serv(WebApplicationBuilder builder)
    {
        //inject DbContext in Asp 
        builder.Services.AddDbContext<DbContextShipment>(option =>
        {
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        // configure Entity framework Table 
        builder.Services.AddIdentity<TbUsers, IdentityRole>(option =>
        {
            option.Password.RequiredLength = 8;
            option.Password.RequireNonAlphanumeric = true;
            option.Password.RequireUppercase = true;
            option.Password.RequireDigit = true;
            option.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<DbContextShipment>()
          .AddDefaultTokenProviders();

        // configure Authentication 
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(option =>
            {
                option.LoginPath = "/LogIn";
                option.AccessDeniedPath = "/AccessDenied";
                option.ExpireTimeSpan = TimeSpan.FromHours(24);
            });

        // configure Authorization
        builder.Services.AddAuthorization();

        // inject Generic repository
        builder.Services.AddScoped(typeof(ItablsGenericRepositorys<>), typeof(TablsGenericRepositorys<>));

        // inject Business Layer 
        builder.Services.AddScoped<IShipmentsServices, ShipmentServices>();
        builder.Services.AddScoped<IAboutUsServices, AboutUsServices>();
        builder.Services.AddScoped<ICarriersServices, CarriersServices>();
        builder.Services.AddScoped<ICitiesServices, CitiesServices>();
        builder.Services.AddScoped<ICountriesServices, CountriesServices>();
        builder.Services.AddScoped<IUsersSenderServices, UsersSenderServices>();
        builder.Services.AddScoped<IUsersServices, UserServices>();
        builder.Services.AddScoped<IUserSubscriptionsServices, UserSubscriptionsServices>();
        builder.Services.AddScoped<IUserReciversServices, UserReceiversServices>();
        builder.Services.AddScoped<IHomeSlidersServices, HomeSlidersServices>();
        builder.Services.AddScoped<ISettingsServices, SettingsServices>();
        builder.Services.AddScoped<IShipmentTypeServices, ShipmentTypeServices>();
        builder.Services.AddScoped<IShipmentStatusServices, ShipmentStatusServices>();
        builder.Services.AddScoped<ISubscriptionPackagesServices, SubsciptionPackagesServices>();
        builder.Services.AddScoped<IPaymentMethodServices, PaymentMethodServices>();

        //Configure serilog
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.MSSqlServer(
                connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
                tableName: "Log",
                autoCreateSqlTable: true
            ).CreateLogger();
        builder.Host.UseSerilog();

        // configur auto mapper
        builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
    }
}
