using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SannaCommerce.WebShop.Domain
{
    public class Order
    {
        public int IdOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public int IdCustomer { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
