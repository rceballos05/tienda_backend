using AutoMapper;
using Tienda.Application.Dtos.Requests;
using Tienda.Application.Dtos.Responses;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Commons.Bases.Responses;

namespace Tienda.Application.Mappers
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductDtoResponse>()
                .ReverseMap();
            CreateMap<BaseEntityResponse<Product>, BaseEntityResponse<ProductDtoResponse>>()
                .ReverseMap();
            CreateMap<ProductDtoRequest, Product>();
        }
    }
}
