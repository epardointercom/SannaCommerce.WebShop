using SannaCommerce.WebShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SannaCommerce.WebShop.Presentation.Web.Models
{
    public class CategoriesModel
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public List<Category> Categories = new List<Category>();
        public bool ToSave { get; set; } = false;
    }
}