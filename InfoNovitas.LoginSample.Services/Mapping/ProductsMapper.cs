using InfoNovitas.LoginSample.Services.Messaging.Views.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Services.Mapping
{
    public static class ProductsMapper
    {
        public static Product MapToProduct(this Model.Products.Product model)
        {
            if (model == null)
                return null;
            return new Product()
            {
                Id = model.Id,
                DateCreated = model.DateCreated,
                UserCreated = model.UserCreated.MapToView(),
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                DateLastModified = model.DateLastModified,
                UserLastModified = model.UserLastModified.MapToView(),
            };
        }

        public static List<Product> MapToProducts(this IEnumerable<Model.Products.Product> items)
        {
            var result = new List<Product>();
            if (items == null)
                return result;
            result.AddRange(items.Select(p => p.MapToProduct()));
            return result;
        }

        public static Model.Products.Product MapToModel(this Messaging.Views.Products.Product view)
        {
            if (view == null)
                return null;
            return new Model.Products.Product()
            {
                Id = view.Id,
                Name = view.Name,
                Price = view.Price,
                Description = view.Description,
                DateCreated = view.DateCreated,
                UserCreated = view.UserCreated.MapToModel(),
                DateLastModified = view.DateLastModified,
                UserLastModified = view.UserLastModified.MapToModel()
            };

        }

    }
}
