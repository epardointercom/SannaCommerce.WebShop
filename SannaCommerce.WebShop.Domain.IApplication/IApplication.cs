using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SannaCommerce.WebShop.Domain.IApplication
{
    public interface IApplication
    {
        #region Categories

        /// <summary>
        /// Create a new category
        /// </summary>
        /// <param name="obj">category object to create</param>
        /// <returns>Category created</returns>
        Category CreatetCategory(Category obj);

        /// <summary>
        /// Get one or more categories
        /// </summary>
        /// <param name="id"></param>
        /// <returns>If id == 0 get all categories, else get category by id</returns>
        List<Category> ReadCategory(int id);

        /// <summary>
        /// Get Categories by IdProduct
        /// </summary>
        /// <param name="idProduct">IdProdcut</param>
        /// <returns>List<Category> of all Categories by Id Product</Category></returns>
        List<Category> ReadCategoryByIdProduct(int idProduct);

        /// <summary>
        /// Update category
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Category uptade</returns>
        Category UpdateCategory(Category obj);

        /// <summary>
        /// Delete category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if is success</returns>
        bool DeleteCategory(int id);

        #endregion

        #region Customers

        /// <summary>
        /// Create a new Customer
        /// </summary>
        /// <param name="obj">Customer object to create</param>
        /// <returns>Customer created</returns>
        Customer CreatetCustomer(Customer obj);

        /// <summary>
        /// Get one or more Customers
        /// </summary>
        /// <param name="id"></param>
        /// <returns>If id == 0 get all Customers, else get Customer by id</returns>
        List<Customer> ReadCustomer(int id);

        /// <summary>
        /// Update Customer
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Customer uptade</returns>
        Customer UpdateCustomer(Customer obj);

        /// <summary>
        /// Delete Customer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if is success</returns>
        bool DeleteCustomer(int id);

        #endregion

        #region Orders

        /// <summary>
        /// Create a new Order
        /// </summary>
        /// <param name="obj">Order object to create</param>
        /// <returns>Order created</returns>
        Order CreateOrder(Order obj);

        /// <summary>
        /// Get one or more Orders
        /// </summary>
        /// <param name="id"></param>
        /// <returns>If id == 0 get all Orders, else get Order by id</returns>
        List<Order> ReadOrder(int id);

        /// <summary>
        /// Get one or more OrderDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns>If id == 0 get all OrderDetail, else get OrderDetail by id</returns>
        List<OrderDetail> ReadOrderDetail(int id);

        /// <summary>
        /// Get one or more OrderDetail
        /// </summary>
        /// <param name="id"></param>
        /// <returns>If id == 0 get all OrderDetail, else get OrderDetail by idOrder</returns>
        List<OrderDetail> ReadOrderDetailByIdOrder(int idOrder);

        /// <summary>
        /// Update Order
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Order uptade</returns>
        Order UpdateOrder(Order obj);

        /// <summary>
        /// Update Details to exist Order
        /// </summary>
        /// <param name="obj">List of OrderDetails</param>
        /// <returns>Order uptade</returns>
        bool UpdateOrderDetails(List<OrderDetail> obj);

        /// <summary>
        /// Delete Order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if is success</returns>
        bool DeleteOrder(int id);

        #endregion

        #region Products

        /// <summary>
        /// Create a new Product
        /// </summary>
        /// <param name="obj">Product object to create</param>
        /// <returns>Product created</returns>
        Product CreatetProduct(Product obj);

        /// <summary>
        /// Get one or more Products
        /// </summary>
        /// <param name="id"></param>
        /// <returns>If id == 0 get all Products, else get Product by id</returns>
        List<Product> ReadProduct(int id);

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Product uptade</returns>
        Product UpdateProduct(Product obj);

        /// <summary>
        /// Update categories to exist prodct
        /// </summary>
        /// <param name="id">IdProduct</param>
        /// <param name="obj">List of IdCategories</param>
        /// <returns>True if is success</returns>
        bool UpdateProductCategories(int id, List<int> obj);

        /// <summary>
        /// Delete Product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if is success</returns>
        bool DeleteProduct(int id);

        #endregion
    }
}
