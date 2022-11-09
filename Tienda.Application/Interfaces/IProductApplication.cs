using Tienda.Application.Commons.Bases;
using Tienda.Application.Dtos.Requests;
using Tienda.Application.Dtos.Responses;
using Tienda.Infrastructure.Commons.Bases.Requests;
using Tienda.Infrastructure.Commons.Bases.Responses;

namespace Tienda.Application.Interfaces
{
    public interface IProductApplication
    {
        Task<BaseResponse<BaseEntityResponse<ProductDtoResponse>>> ListProduct(BaseFilterRequest filters);
        Task<BaseResponse<ProductDtoResponse>> ProductById(int id);
        Task<BaseResponse<bool>> DeleteProduct(int id);
        Task<BaseResponse<bool>> RegisterProduct(ProductDtoRequest productDto);
        Task<BaseResponse<bool>> EditProduct(int id, ProductDtoRequest productDto);
    }
}
