using CleanArchitectureTemplate.Application.Interfaces.Repositories;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Infrastructure.Persistence.Contexts;
using CleanArchitectureTemplate.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Repositories
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
