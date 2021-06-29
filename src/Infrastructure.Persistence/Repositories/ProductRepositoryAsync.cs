using CarDataPlatformIngestor.Application.Interfaces.Repositories;
using CarDataPlatformIngestor.Domain.Entities;
using CarDataPlatformIngestor.Infrastructure.Persistence.Contexts;
using CarDataPlatformIngestor.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarDataPlatformIngestor.Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
    {
        private readonly DbSet<Product> products;

        public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            products = dbContext.Set<Product>();
        }

        public Task<bool> IsUniqueBarcodeAsync(string barcode)
        {
            return products
                .AllAsync(p => p.Barcode != barcode);
        }
    }
}
