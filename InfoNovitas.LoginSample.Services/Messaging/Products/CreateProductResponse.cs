namespace InfoNovitas.LoginSample.Services.Messaging.Products
{
    public class CreateProductResponse:LoginSampleResponseBase<CreateProductRequest>
    {
        public Views.Products.Product Product { get; set; }
    }
}
