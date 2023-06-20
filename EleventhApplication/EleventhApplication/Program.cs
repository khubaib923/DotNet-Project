using EleventhApplication.IServices;
using EleventhApplication.Models;
using EleventhApplication.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IMyService,MyService>();
builder.Services.Configure<WeatherApiOption>(
builder.Configuration.GetSection("key")
);
builder.Configuration.AddJsonFile("MyOwnConfig.json",optional:true,reloadOnChange:true);

//builder.Host.ConfigureAppConfiguration((hostContext, config) =>
//{
//    config.AddJsonFile("MyOwnConfig.json");
//});
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        string value = app.Configuration["MyKey"];
        string value1 = app.Configuration.GetValue<string>("Key","key is not presents");
        await context.Response.WriteAsync(value+ "\n");
        await context.Response.WriteAsync(value1);

    });
});
app.MapControllers();


app.Run();
