using SannaCommerce.WebShop.Domain.IApplication;
using SannaCommerce.WebShop.Domain.IRepository;
using SannaCommerce.WebShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SannaCommerce.WebShop.Application
{
    public class Application : IApplication
    {

        private readonly IWebShopRepository _webShopRepository;

        public Application(IWebShopRepository webShopRepository) // Injection Constructor Unity
        {
            _webShopRepository = webShopRepository;
        }

        #region Categories

        public Category CreatetCategory(Category obj)
        {
            return _webShopRepository.CreatetCategory(obj);
        }

        public List<Category> ReadCategory(int id)
        {
            return _webShopRepository.ReadCategory(id);
        }

        public List<Category> ReadCategoryByIdProduct(int idProduct)
        {
            return _webShopRepository.ReadCategoryByIdProduct(idProduct);
        }

        public Category UpdateCategory(Category obj)
        {
            return _webShopRepository.UpdateCategory(obj);
        }

        public bool DeleteCategory(int id)
        {
            return _webShopRepository.DeleteCategory(id);
        }

        #endregion

        #region Customers

        public Customer CreatetCustomer(Customer obj)
        {
            return _webShopRepository.CreatetCustomer(obj);
        }

        public List<Customer> ReadCustomer(int id)
        {
            return _webShopRepository.ReadCustomer(id);
        }

        public Customer UpdateCustomer(Customer obj)
        {
            return _webShopRepository.UpdateCustomer(obj);
        }

        public bool DeleteCustomer(int id)
        {
            return _webShopRepository.DeleteCustomer(id);
        }

        #endregion

        #region Orders

        public Order CreateOrder(Order obj)
        {
            return _webShopRepository.CreateOrder(obj);
        }

        public List<Order> ReadOrder(int id)
        {
            return _webShopRepository.ReadOrder(id);
        }

        public List<OrderDetail> ReadOrderDetail(int id)
        {
            return _webShopRepository.ReadOrderDetail(id);
        }

        public List<OrderDetail> ReadOrderDetailByIdOrder(int idOrder)
        {
            return _webShopRepository.ReadOrderDetailByIdOrder(idOrder);
        }

        public Order UpdateOrder(Order obj)
        {
            return _webShopRepository.UpdateOrder(obj);
        }

        public bool UpdateOrderDetails(List<OrderDetail> obj)
        {
            return _webShopRepository.UpdateOrderDetails(obj);
        }

        public bool DeleteOrder(int id)
        {
            return _webShopRepository.DeleteOrder(id);
        }

        #endregion

        #region Products

        public Product CreatetProduct(Product obj)
        {
            return _webShopRepository.CreatetProduct(obj);
        }

        public List<Product> ReadProduct(int id)
        {
            return _webShopRepository.ReadProduct(id);
        }

        public Product UpdateProduct(Product obj)
        {
            return _webShopRepository.UpdateProduct(obj);
        }

        public bool UpdateProductCategories(int id, List<int> obj)
        {
            return _webShopRepository.UpdateProductCategories(id, obj);
        }

        public bool DeleteProduct(int id)
        {
            return _webShopRepository.DeleteProduct(id);
        }

        #endregion
    }
}
