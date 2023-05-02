using Newtonsoft.Json.Linq;
using RestuarantProjectMVC.Models;

namespace RestuarantProjectMVC;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<string>((s) =>
        {
            var key = File.ReadAllText("appsettings.json");
            string conn = JObject.Parse(key).GetValue("APIKey").ToString();
            return conn;
        });
        builder.Services.AddTransient<IRestaurantMVCRepository, RestaurantMVCRepository>();
        builder.Services.AddControllersWithViews();
        builder.Services.AddControllersWithViews()
            .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition =
            System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull);
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
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}

