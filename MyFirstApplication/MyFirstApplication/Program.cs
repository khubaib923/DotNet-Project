using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.WebUtilities;
using System.IO;
using MyFirstApplication.CustomMiddleware;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
WebApplication app = builder.Build();



//app.MapGet("/", () => "Hello World!");


//app.Run(async (HttpContext context) =>
//{
//string path=context.Request.Path;
//context.Response.Headers["Content-Type"] = "text/html";
//if (context.Request.Method == "GET")
//{
//    if (context.Request.Query.ContainsKey("Id"))
//    {
//        string id = context.Request.Query["Id"]!;
//        await context.Response.WriteAsync(id);

//    }
//}

//context.Response.Headers["Content-Type"] = "text/html";
//StreamReader reader = new StreamReader(context.Request.Body);
//string bodyData = await reader.ReadToEndAsync();
//Dictionary<string,StringValues>data=QueryHelpers.ParseQuery(bodyData);
//if (data.ContainsKey("age"))
//{
//    string name = data["age"][1]!;
//    await context.Response.WriteAsync(name);
//}
//if (context.Request.Headers.ContainsKey("Authorization"))
//{
//    string userAgent = context.Request.Headers["Authorization"]!;
//    await context.Response.WriteAsync(userAgent);
//}

//await context.Response.WriteAsync("<h1>Hello</h1>");
//await context.Response.WriteAsync("<h2>World</h2>");
//string method = context.Request.Method;
//await context.Response.WriteAsync(method);
//context.Response.Headers["MyKey"] = "my value";
//context.Response.StatusCode = 404;
//});

//MiddleWare


//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("Hello");
//    await next(context);
//    await context.Response.WriteAsync(" Khubaib");
//});

//app.UseMiddleware<MyCustomMiddleware>();

//app.UseMyCustomMiddleware();

//app.UseHelloMiddleware();

//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync(" World");
//});

app.UseWhen((HttpContext context) => context.Request.Query.ContainsKey("username"),
            app =>
            {
                app.Use(async (HttpContext context,RequestDelegate next) =>
                {

                    await context.Response.WriteAsync("Hello");
                    await next(context);

                });


            });
app.Run(async (HttpContext context) =>
{
   await context.Response.WriteAsync(" World");
});
//app.UseExceptionHandler();
//app.UseHsts();
//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();
//app.UseSession();
//app.MapControllers();
app.Run();



