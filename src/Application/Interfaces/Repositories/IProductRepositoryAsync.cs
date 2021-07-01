using CleanArchitectureTemplate.Domain.Entities;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Interfaces.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
    {
        Task<bool> IsUniqueBarcodeAsync(string barcode);
    }
}
