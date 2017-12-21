using InfoNovitas.LoginSample.Model.Products;
using InfoNovitas.LoginSample.Model.Users;
using InfoNovitas.LoginSample.Services;
using InfoNovitas.LoginSample.Services.Messaging.Products;
using InfoNovitas.LoginSample.Web.Api.Helpers;
using InfoNovitas.LoginSample.Web.Api.Mapping;
using InfoNovitas.LoginSample.Web.Api.Models.Products;
using InfoNovitas.LoginSample.Web.Api.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace InfoNovitas.LoginSample.Web.Api.Controllers
{
    [Authorize]
    public class ProductsController:ApiController
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();

            var request = new GetAllProductsRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId
            };

            var response = _productService.GetAllProducts(request);

            if (response.Success)
            {
                return Ok(response.Products.MapToProductsViewModel());
            }

            return BadRequest(response.Message);
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody] ProductViewModel product)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();
            product.DateCreated = DateTime.Now;
            product.UserCreated = new UserViewModel()
            {
                Id = loggedUserId
            };

            var request = new CreateProductRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Product = product.MapToProductView()
            };

            var response = _productService.CreateProduct(request);

            if (response.Success)
            {
                return Ok(response.Product.MapToProductViewModel());
            }

            return BadRequest(response.Message);
        }

        [HttpPut]
        public IHttpActionResult Put(ProductViewModel product)
        {
            var loggedUserId = HttpContext.Current.GetOwinContext().GetUserId();
            product.DateLastModified = DateTime.Now;
            product.UserLastModified = new UserViewModel()
            {
                Id = loggedUserId
            };

            var request = new UpdateProductRequest()
            {
                RequestToken = Guid.NewGuid(),
                UserId = loggedUserId,
                Product = product.MapToProductView()
            };

            var response = _productService.UpdateProduct(request);

            if (response.Success)
            {
                return Ok(response.Product.MapToProductViewModel());
            }

            return BadRequest(response.Message);
        }


    }
}