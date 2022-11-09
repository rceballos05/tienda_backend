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
    public class ProductApplication : IProductApplication
    {
        private readonly IUnitOfWorks unitOfWorks;
        private readonly IMapper mapper;
        private readonly ProductValidator validations;
        public ProductApplication(IUnitOfWorks _unitOfWorks, IMapper _mapper, ProductValidator _validations)
        {
            unitOfWorks = _unitOfWorks;
            mapper = _mapper;
            validations = _validations;
        }
        public async Task<BaseResponse<bool>> DeleteProduct(int id)
        {
            var response = new BaseResponse<bool>();
            var product = await ProductById(id);

            if (product.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            response.Data = await unitOfWorks.Product.RemoveAsync(id);
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

        public async Task<BaseResponse<bool>> EditProduct(int id, ProductDtoRequest productDto)
        {
            var response = new BaseResponse<bool>();
            var editproduct = await ProductById(id);
            if (editproduct.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            var product = mapper.Map<Product>(productDto);
            product.Id = id;
            response.Data = await unitOfWorks.Product.EditAsync(product);
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

        public async Task<BaseResponse<BaseEntityResponse<ProductDtoResponse>>> ListProduct(BaseFilterRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<ProductDtoResponse>>();
            var product = await unitOfWorks.Product.ListProduct(filters);
            if (product is not null)
            {
                response.IsSuccess = true;
                response.Data = mapper.Map<BaseEntityResponse<ProductDtoResponse>>(product);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<ProductDtoResponse>> ProductById(int id)
        {
            var response = new BaseResponse<ProductDtoResponse>();
            var product = await ProductById(id);
            if (product is not null)
            {
                response.IsSuccess = true;
                response.Data = mapper.Map<ProductDtoResponse>(product);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegisterProduct(ProductDtoRequest productDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await validations.ValidateAsync(productDto);
            if (!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATION;
                response.Errors = validationResult.Errors;
                return response;
            }
            var product = mapper.Map<Product>(productDto);
            response.Data = await unitOfWorks.Product.RegisterAsync(product);
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
