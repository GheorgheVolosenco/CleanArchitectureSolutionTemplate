using AutoMapper;
using CleanArchitectureTemplate.Application.DTOs.Product.Requests;
using CleanArchitectureTemplate.Application.DTOs.Product.Responses;
using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Application.Mappings
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
