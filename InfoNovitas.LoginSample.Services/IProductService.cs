using InfoNovitas.LoginSample.Services.Messaging.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services
{
    public interface IProductService
    {
        GetAllProductsResponse GetAllProducts(GetAllProductsRequest request);
        CreateProductResponse CreateProduct(CreateProductRequest request);
        UpdateProductResponse UpdateProduct(UpdateProductRequest request);
    }
}
