using SannaCommerce.WebShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SannaCommerce.WebShop.Presentation.Web.Models
{
    public class OrdersModel
    {
        public int IdOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public int IdCustomer { get; set; }
        public string JsonOrderDetails { get; set; }
        public List<Order> Orders = new List<Order>();
        public List<OrderDetail> OrderDetails = new List<OrderDetail>();
        public List<Customer> Customers = new List<Customer>();
        public List<Product> Products = new List<Product>();
        public bool ToSave { get; set; } = false;
    }
}