using InfoNovitas.LoginSample.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoNovitas.LoginSample.Repositories.Mapping
{
    public static class ProductsMapper
    {
        public static Product MapToProduct(this DatabaseModel.Product model)
        {
            if (model == null)
                return null;
            return new Product()
            {
                Id = model.Id,
                DateCreated = model.DateCreated,
                UserCreated = model.UserInfo.MapToUserInfo(),
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                DateLastModified = model.LastModified,
                UserLastModified = model.UserInfo1.MapToUserInfo()
            };
        }

        public static List<Model.Products.Product> MapToProducts(this IEnumerable<DatabaseModel.Product> items)
        {
            var result = new List<Model.Products.Product>();
            if (items == null)
                return result;
            result.AddRange(items.Select(p => p.MapToProduct()));
            return result;
        }
    }
}
