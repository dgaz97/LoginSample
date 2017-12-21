using InfoNovitas.LoginSample.Services.Messaging.Views.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services.Messaging.Products
{
    public class GetAllProductsResponse:LoginSampleResponseBase<GetAllProductsRequest>
    {
        public List<Product> Products { get; set; }
    }
}
