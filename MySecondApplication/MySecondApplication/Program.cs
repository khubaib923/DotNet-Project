using Microsoft.Extensions.FileProviders;
using MySecondApplication.CustomConstraints;

WebApplicationBuilder builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "myroot"
}); ;
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("city", typeof(MyCustomConstraints));
});
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.Use(async (context, next) =>
//{
//    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
//    await next(context);
//});
app.UseStaticFiles();//works with the web root
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "mywebroot")
        )
});

app.UseRouting();

//app.Use(async (context, next) =>
//{
//    Microsoft.AspNetCore.Http.Endpoint? endpoint = context.GetEndpoint();
//    await next(context);
//});

//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/files/{file=hello}/{extension=txt}", async (context) =>
//    {

//        string? file = Convert.ToString(context.Request.RouteValues["file"]);
//        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

//        await context.Response.WriteAsync($"files are {file}{extension}");


//    });
//});

//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/value/{id?}", async (context) =>
//    {
//        int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
//        await context.Response.WriteAsync($"id are {id}");

//    });
//});

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("map1", async (context) =>
//    {

//        await context.Response.WriteAsync("map 1");
//    });
//});

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapPost("map2", async (context) =>
//    {
//        await context.Response.WriteAsync("map 2");
//    });
//});

//Route Constraint
//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/product/details/{id:int?}", async (context) =>
//    {
//        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
//        await context.Response.WriteAsync($"id are {id}");
//    });
//});

//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/item/{reportdate:datetime?}", async (context) =>
//    {
//        DateTime date = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
//        await context.Response.WriteAsync($"reportdate are {date.ToShortDateString()}");
//    });
//});


//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/company/{code:guid?}", async (context) =>
//    {
//        Guid guid = Guid.Parse(Convert.ToString(context.Request.RouteValues["code"])!);
//        await context.Response.WriteAsync($"reportdate are {guid}");
//    });
//});

//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/company/{name:range(5,10)?}", async (context) =>
//    {
//        if (context.Request.RouteValues.ContainsKey("name"))
//        {
//            string? name = Convert.ToString(context.Request.RouteValues["name"]);
//            await context.Response.WriteAsync($"name are {name}");
//        }

//    });
//});

//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/company/{city:regex(^(apr|may|jun)$)}", async (context) =>
//    {
//        if (context.Request.RouteValues.ContainsKey("city"))
//        {
//            string? name = Convert.ToString(context.Request.RouteValues["city"]);
//            await context.Response.WriteAsync($"name are {name}");
//        }

//    });
//});

//custom constraint used

//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/company/{city:city}", async (context) =>
//    {
//        if (context.Request.RouteValues.ContainsKey("city"))
//        {
//            string? name = Convert.ToString(context.Request.RouteValues["city"]);
//            await context.Response.WriteAsync($"name are {name}");
//        }

//    });
//});

//app.UseEndpoints(endpoints =>
//{
//    endpoints.Map("/company/jun", async (context) =>
//    {


//            await context.Response.WriteAsync($"name was jun");


//    });
//});

app.Run(async (HttpContext context) =>
{
    string path = context.Request.Path;
    await context.Response.WriteAsync($"No route found with respect to {path}");
});

app.Run();
