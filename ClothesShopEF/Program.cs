using ClothesShopEF;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context,services) =>
    {
        services.AddHostedService<Worker>();
        services.AddDbContext<ClothesDb>(options =>
        {
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection"));
        },ServiceLifetime.Singleton);
    })
    .Build();

host.Run();
