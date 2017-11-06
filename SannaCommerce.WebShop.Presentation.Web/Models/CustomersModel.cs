using SannaCommerce.WebShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SannaCommerce.WebShop.Presentation.Web.Models
{
    public class CustomersModel
    {
        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public List<Customer> Customers = new List<Customer>();
        public bool ToSave { get; set; } = false;
    }
}