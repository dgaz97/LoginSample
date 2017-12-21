using InfoNovitas.LoginSample.Services.Messaging.Views.Users;
using System;

namespace InfoNovitas.LoginSample.Services.Messaging.Views.Products
{
    public class Product
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public UserInfo UserCreated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? DateLastModified { get; set; }
        public UserInfo UserLastModified { get; set; }
    }
}
