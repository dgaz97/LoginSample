using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services.Messaging.Products
{
    public class UpdateProductResponse: LoginSampleResponseBase<UpdateProductRequest>
    {
        public Views.Products.Product Product { get; set; }
    }
}
