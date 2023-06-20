using MyThirdApplication.Controllers;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<HomeController>();
builder.Services.AddControllers();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//app.UseRouting();
app.UseStaticFiles();
app.MapControllers();

app.Run();
