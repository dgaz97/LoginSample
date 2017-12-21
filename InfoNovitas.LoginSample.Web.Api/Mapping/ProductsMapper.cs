using InfoNovitas.LoginSample.Web.Api.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Views = InfoNovitas.LoginSample.Services.Messaging.Views;

namespace InfoNovitas.LoginSample.Web.Api.Mapping
{
    public static class ProductsMapper
    {
        public static ProductViewModel MapToProductViewModel(this Views.Products.Product view)
        {
            if (view == null)
                return null;

            return new ProductViewModel()
            {
                Id = view.Id,
                DateCreated = view.DateCreated,
                UserCreated = view.UserCreated.MapToViewModel(),
                Name = view.Name,
                Description = view.Description,
                Price = view.Price,
                DateLastModified = view.DateLastModified,
                UserLastModified = view.UserLastModified.MapToViewModel()
            };
        }

        public static Views.Products.Product MapToProductView(this ProductViewModel viewModel)
        {
            if (viewModel == null)
                return null;

            return new Views.Products.Product()
            {
                Id = viewModel.Id,
                DateCreated = viewModel.DateCreated,
                UserCreated = viewModel.UserCreated.MapToView(),
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                DateLastModified = viewModel.DateLastModified,
                UserLastModified = viewModel.UserLastModified.MapToView()
            };
        }

        public static List<ProductViewModel> MapToProductsViewModel(this IEnumerable<Views.Products.Product> items)
        {
            var result = new List<ProductViewModel>();
            if (items == null)
                return result;
            result.AddRange(items.Select(p => p.MapToProductViewModel()));
            return result;
        }
    }
}