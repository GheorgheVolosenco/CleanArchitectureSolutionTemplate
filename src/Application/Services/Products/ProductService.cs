using AutoMapper;
using CarDataPlatformIngestor.Application.DTOs.Product.Requests;
using CarDataPlatformIngestor.Application.DTOs.Product.Responses;
using CarDataPlatformIngestor.Application.Exceptions;
using CarDataPlatformIngestor.Application.Interfaces.Repositories;
using CarDataPlatformIngestor.Application.Wrappers;
using CarDataPlatformIngestor.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Products
{
    public class ProductService
    {
        private readonly IProductRepositoryAsync productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepositoryAsync productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllProductsResponse>>> GetAllProducts(GetAllProductsRequest model, CancellationToken cancellationToken)
        {
            var validFilter = mapper.Map<GetAllProductsParameter>(model);
            var product = await productRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var productsResponseModel = mapper.Map<IEnumerable<GetAllProductsResponse>>(product);
            return new PagedResponse<IEnumerable<GetAllProductsResponse>>(productsResponseModel, validFilter.PageNumber, validFilter.PageSize);
        }

        public async Task<Response<ProductResponse>> GetProductById(GetProductByIdRequest model, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(model.Id);

            if (product == null)
            {
                throw new ApiException($"Product Not Found.");
            }

            var productResponseModel = mapper.Map<ProductResponse>(product);
            return new Response<ProductResponse>(productResponseModel);
        }

        public async Task<Response<int>> AddProduct(CreateProductRequest model, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(model);
            await productRepository.AddAsync(product);
            return new Response<int>(product.Id);
        }

        public async Task<Response<int>> UpdateProduct(UpdateProductRequest model, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(model.Id);

            if (product == null)
            {
                throw new ApiException($"Product Not Found.");
            }
            else
            {
                product.Name = model.Name;
                product.Rate = model.Rate;
                product.Description = model.Description;
                await productRepository.UpdateAsync(product);
                return new Response<int>(product.Id);
            }
        }

        public async Task<Response<int>> DeleteProduct(DeleteProductByIdRequest model, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(model.Id);

            if (product == null)
            {
                throw new ApiException($"Product Not Found.");
            }

            await productRepository.DeleteAsync(product);
            return new Response<int>(product.Id);
        }
    }
}
