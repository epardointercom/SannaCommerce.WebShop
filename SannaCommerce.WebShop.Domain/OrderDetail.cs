using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SannaCommerce.WebShop.Domain
{
    public class OrderDetail
    {
        public int IdOrderDetail { get; set; }
        public int IdOrder { get; set; }
        public string NameProduct { get; set; }
        public int IdProduct { get; set; }
        public int QuantityProducts { get; set; }
    }
}
