using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ClothesShop.DAL.Data;

namespace ClothesShopEF;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ClothesDb clothesDb;

    public Worker(ILogger<Worker> logger, ClothesDb clothesDb)
    {
        _logger = logger;
        this.clothesDb = clothesDb;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        InitialData data = new InitialData();
        await clothesDb.ShoesEntities.AddRangeAsync(data.ShoesData);
        await clothesDb.ClothingEntities.AddRangeAsync(data.ClothingData);
        await clothesDb.AccessoriesEntities.AddRangeAsync(data.AccessoriesData);

        await clothesDb.SaveChangesAsync();

        while (!stoppingToken.IsCancellationRequested)
        { 
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
