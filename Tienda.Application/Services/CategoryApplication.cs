using AutoMapper;
using Tienda.Application.Commons.Bases;
using Tienda.Application.Dtos.Requests;
using Tienda.Application.Dtos.Responses;
using Tienda.Application.Interfaces;
using Tienda.Application.Validators;
using Tienda.Domain.Entities;
using Tienda.Infrastructure.Commons.Bases.Requests;
using Tienda.Infrastructure.Commons.Bases.Responses;
using Tienda.Infrastructure.Persistences.Interfaces;
using Tienda.Utilities.Statics;

namespace Tienda.Application.Services
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly IUnitOfWorks unitOfWorks;
        private readonly IMapper mapper;
        private readonly CategoryValidator validations;
        public CategoryApplication(IUnitOfWorks _unitOfWorks, IMapper _mapper, CategoryValidator _validations)
        {
            unitOfWorks = _unitOfWorks;
            mapper = _mapper;
            validations = _validations;
        }
        public async Task<BaseResponse<CategoryDtoResponse>> CategoryById(int id)
        {
            var response = new BaseResponse<CategoryDtoResponse>();
            var category = await unitOfWorks.Category.GetByIdAsync(id);

            if (category is not null)
            {
                response.IsSuccess = true;
                response.Data = mapper.Map<CategoryDtoResponse>(category);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> DeleteCategory(int id)
        {
            var response = new BaseResponse<bool>();
            var category = await CategoryById(id);
            if (category.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            response.Data = await unitOfWorks.Category.RemoveAsync(id);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;

            }

            return response;
        }

        public async Task<BaseResponse<bool>> EditCategory(int id, CategoryDtoRequest categoryDto)
        {
            var response = new BaseResponse<bool>();
            var editCategory = await CategoryById(id);

            if (editCategory.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            var category = mapper.Map<Category>(categoryDto);
            category.Id = id;
            response.Data = await unitOfWorks.Category.EditAsync(category);
            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

        public async Task<BaseResponse<BaseEntityResponse<CategoryDtoResponse>>> ListCategory(BaseFilterRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<CategoryDtoResponse>>();
            var category = await unitOfWorks.Category.ListCategory(filters);
            if (category is not null)
            {
                response.IsSuccess = true;
                response.Data = mapper.Map<BaseEntityResponse<CategoryDtoResponse>>(category);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<IEnumerable<CategoryDtoResponse>>> ListCategoryCombobox()
        {
            var response = new BaseResponse<IEnumerable<CategoryDtoResponse>>();
            var category = await unitOfWorks.Category.GetAllAsync();

            if (category is not null)
            {
                response.IsSuccess = true;
                response.Data = mapper.Map<IEnumerable<CategoryDtoResponse>>(category);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterCategory(CategoryDtoRequest categoryDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await validations.ValidateAsync(categoryDto);

            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATION;
                response.Errors = validationResult.Errors;
                return response;
            }

            var category = mapper.Map<Category>(categoryDto);
            response.Data = await unitOfWorks.Category.RegisterAsync(category);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }
    }
}
