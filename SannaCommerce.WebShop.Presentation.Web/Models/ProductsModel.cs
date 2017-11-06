using SannaCommerce.WebShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SannaCommerce.WebShop.Presentation.Web.Models
{
    public class ProductsModel
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public virtual int[] ProductCategories { get; set; }
        public List<Product> Products = new List<Product>();
        public List<Category> Categories = new List<Category>();
        public List<Category> AllCategories = new List<Category>();
        public bool ToSave { get; set; } = false;
    }
}