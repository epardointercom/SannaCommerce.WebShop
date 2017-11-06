using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SannaCommerce.WebShop.Domain
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
