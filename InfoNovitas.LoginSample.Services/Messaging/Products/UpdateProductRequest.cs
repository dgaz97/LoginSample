using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services.Messaging.Products
{
    public class UpdateProductRequest: LoginSampleRequestBase
    {
        public Views.Products.Product Product { get; set; }
    }
}
