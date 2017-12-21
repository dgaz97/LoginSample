using InfoNovitas.LoginSample.Model.Products;
using InfoNovitas.LoginSample.Repositories.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using Context = InfoNovitas.LoginSample.Repositories.DatabaseModel;

namespace InfoNovitas.LoginSample.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> FindAll()
        {
            using (var context = new Context.IdentityExDbEntities())
            {
                return context.Products.MapToProducts();
            }
        }

        public int Add(Product product)
        {
            int id = 0;
            using (var context = new Context.IdentityExDbEntities())
            {
                var addProduct = new DatabaseModel.Product()
                {
                    Active = true,
                    DateCreated =product.DateCreated,
                    Name = product.Name,
                    Price = product.Price,
                    UserCreated = product.UserCreated.Id,
                    Description = product.Description
                };
                id = context.Products.Add(addProduct).Id;
                context.SaveChanges();
            }
            return id;
        }

        public Product Save(Product item)
        {
            int id = item.Id;
        
            using (var context = new Context.IdentityExDbEntities())
            {
                var product = context.Products.Single(p => p.Id == id);

                product.Name = item.Name;
                product.Description = item.Description;
                product.Price = item.Price;
                product.LastModified = item.DateLastModified;
                product.UserLastModified = item.UserLastModified.Id;
                context.SaveChanges();
                return item;
            }
            
            
        }

        #region Not implemented

        public bool Delete(Product item)
        {
            throw new NotImplementedException();
        }



        public Product FindBy(int key)
        {
            throw new NotImplementedException();
        }

       

        #endregion
    }
}
