using Microsoft.AspNetCore.Authentication.Cookies;
using Serilog;
using Serilog.AspNetCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Configuration.AddJsonFile("appsettings.json");
        builder.Host.UseSerilog();
        builder.Services.AddAuthentication("Cookies")
            .AddCookie(CookieOption);

        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json").Build();
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();

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

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

    private static void  CookieOption(CookieAuthenticationOptions option)
    {        
        option.LoginPath = "/user/login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(15);
        option.SlidingExpiration = true;        
    }
}