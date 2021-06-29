using CarDataPlatformIngestor.Domain.Entities;
using System.Threading.Tasks;

namespace CarDataPlatformIngestor.Application.Interfaces.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
    {
        Task<bool> IsUniqueBarcodeAsync(string barcode);
    }
}
