using System;
using InfoNovitas.LoginSample.Model.Products;
using InfoNovitas.LoginSample.Services.Messaging.Products;
using InfoNovitas.LoginSample.Services.Messaging;
using InfoNovitas.LoginSample.Services.Mapping;

namespace InfoNovitas.LoginSample.Services.Impl
{
    public class ProductService:IProductService
    {
        private IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public CreateProductResponse CreateProduct(CreateProductRequest request)
        {
            var response = new CreateProductResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                _repository.Add(request.Product.MapToModel());
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = GenericErrorMessageFactory.GeneralError;
            }

            return response;
        }

        public GetAllProductsResponse GetAllProducts(GetAllProductsRequest request)
        {
            var response = new GetAllProductsResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                response.Products = _repository.FindAll().MapToProducts();
                response.Success = true;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = GenericErrorMessageFactory.GeneralError;
            }

            return response;
        }

        public UpdateProductResponse UpdateProduct(UpdateProductRequest request)
        {
             var response = new UpdateProductResponse()
            {
                Request = request,
                ResponseToken = Guid.NewGuid()
            };

            try
            {
                _repository.Save(request.Product.MapToModel());
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = GenericErrorMessageFactory.GeneralError;
            }

            return response;
        }
    }
}
