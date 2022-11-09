using Tienda.Application.Commons.Bases;
using Tienda.Application.Dtos.Requests;
using Tienda.Application.Dtos.Responses;
using Tienda.Infrastructure.Commons.Bases.Requests;
using Tienda.Infrastructure.Commons.Bases.Responses;

namespace Tienda.Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task<BaseResponse<BaseEntityResponse<CategoryDtoResponse>>> ListCategory(BaseFilterRequest filters);
        Task<BaseResponse<IEnumerable<CategoryDtoResponse>>> ListCategoryCombobox();
        Task<BaseResponse<CategoryDtoResponse>> CategoryById(int id);
        Task<BaseResponse<bool>> DeleteCategory(int id);
        Task<BaseResponse<bool>> RegisterCategory(CategoryDtoRequest categoryDto);
        Task<BaseResponse<bool>> EditCategory(int id, CategoryDtoRequest categoryDto);
    }
}
