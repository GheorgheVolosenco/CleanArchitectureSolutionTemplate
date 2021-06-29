using AutoMapper;
using CarDataPlatformIngestor.Application.DTOs.Product.Requests;
using CarDataPlatformIngestor.Application.DTOs.Product.Responses;
using CarDataPlatformIngestor.Domain.Entities;

namespace CarDataPlatformIngestor.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsResponse>().ReverseMap();
            CreateMap<CreateProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
            CreateMap<GetAllProductsRequest, GetAllProductsParameter>();
        }
    }
}
