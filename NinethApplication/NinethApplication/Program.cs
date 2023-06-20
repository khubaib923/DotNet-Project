using Autofac;
using Autofac.Extensions.DependencyInjection;
using ContractService;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.AddControllersWithViews();
//builder.Services.Add(new ServiceDescriptor(
//    typeof(ICitiesService),
//    typeof(CitiesService),
//    ServiceLifetime.Singleton
//    ));

//builder.Services.AddTransient<ICitiesService,CitiesService>();
builder.Services.AddScoped<ICitiesService, CitiesService>();
//builder.Services.AddSingleton<ICitiesService, CitiesService>();

builder.Host.ConfigureContainer<ContainerBuilder>(ContainerBuilder =>
{
    ContainerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency();
});


//builder.Host.ConfigureContainer<ContainerBuilder>(ContainerBuilder =>
//{
//    ContainerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope();
//});

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


app.Run();
