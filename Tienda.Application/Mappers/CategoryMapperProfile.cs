using AutoMapper;
using Tienda.Application.Dtos.Requests;
using Tienda.Application.Dtos.Responses;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Commons.Bases.Responses;

namespace Tienda.Application.Mappers
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<Category, CategoryDtoResponse>()
                .ReverseMap();
            CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryDtoResponse>>()
                .ReverseMap();
            CreateMap<CategoryDtoRequest, Category>();
        }
    }
}
