using Yarp.ReverseProxy.Transforms;

var webApplicationOptions = new WebApplicationOptions() { ContentRootPath = AppContext.BaseDirectory, Args = args, ApplicationName = System.Diagnostics.Process.GetCurrentProcess().ProcessName };
var builder = WebApplication.CreateBuilder(webApplicationOptions);

builder.Host.UseWindowsService();
// Add services to the container.

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"))
    .AddTransforms(builderContext =>
    {

    }); ;
builder.Services.AddLettuceEncrypt();

var app = builder.Build();
app.MapReverseProxy();
app.Run();
