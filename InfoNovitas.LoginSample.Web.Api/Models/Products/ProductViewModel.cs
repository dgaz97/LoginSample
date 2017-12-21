using InfoNovitas.LoginSample.Web.Api.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoNovitas.LoginSample.Web.Api.Models.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public UserViewModel UserCreated { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? DateLastModified { get; set; }
        public UserViewModel UserLastModified { get; set; }
    }
}