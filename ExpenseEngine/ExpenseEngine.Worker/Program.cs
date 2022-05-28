using ExpenseEngine.Core.Options;
using ExpenseEngine.Core.Services;
using ExpenseEngine.Domain;
using ExpenseEngine.Worker;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext,services) =>
    {
        IConfiguration configuration = hostContext.Configuration;
        services.AddHostedService<Worker>();
        services.AddDbContext<ExpenseContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("ExpenseContext")));
        services.AddScoped<IExpenseReaderService, ExpenseReaderService>();
        services.AddScoped<ITaggingService, TaggingService>();
    })
    .Build();

await host.RunAsync();
