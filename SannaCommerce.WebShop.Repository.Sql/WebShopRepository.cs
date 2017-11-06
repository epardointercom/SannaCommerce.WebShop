using SannaCommerce.WebShop.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SannaCommerce.WebShop.Domain;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace SannaCommerce.WebShop.Repository.Sql
{
    public class WebShopRepository : IWebShopRepository
    {
        private readonly string _connectionString;

        public WebShopRepository(string connectionString) // Injection Constructor Unity
        {
            _connectionString = connectionString;
        }

        #region Categories

        public Category CreatetCategory(Category obj)
        {
            var result = new Category();

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Name", obj.Name);
                    param.Add("@Code", obj.Code);
                    param.Add("@Description", obj.Description);

                    result = db.Query<Category>("CreatetCategory", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public List<Category> ReadCategory(int id)
        {
            var result = new List<Category>();

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdCategory", id);

                    result = db.Query<Category>("ReadCategory", param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public List<Category> ReadCategoryByIdProduct(int idProduct)
        {
            var result = new List<Category>();

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdProduct", idProduct);

                    result = db.Query<Category>("ReadCategoryByIdProduct", param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public Category UpdateCategory(Category obj)
        {
            var result = new Category();

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdCategory", obj.IdCategory);
                    param.Add("@Name", obj.Name);
                    param.Add("@Code", obj.Code);
                    param.Add("@Description", obj.Description);

                    db.Query("UpdateCategory", param, commandType: CommandType.StoredProcedure);
                    result = obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool DeleteCategory(int id)
        {
            var result = false;

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdCategory", id);

                    db.Query("DeleteCategory", param, commandType: CommandType.StoredProcedure);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        #endregion

        #region Customers

        public Customer CreatetCustomer(Customer obj)
        {
            var result = new Customer();

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Name", obj.Name);
                    param.Add("@Phone", obj.Phone);
                    param.Add("@Address", obj.Address);
                    param.Add("@Email", obj.Email);
                    param.Add("@Birthdate", obj.Birthdate);

                    result = db.Query<Customer>("CreatetCustomer", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public List<Customer> ReadCustomer(int id)
        {
            var result = new List<Customer>();

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdCustomer", id);

                    result = db.Query<Customer>("ReadCustomer", param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public Customer UpdateCustomer(Customer obj)
        {
            var result = new Customer();

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdCustomer", obj.IdCustomer);
                    param.Add("@Name", obj.Name);
                    param.Add("@Phone", obj.Phone);
                    param.Add("@Address", obj.Address);
                    param.Add("@Email", obj.Email);
                    param.Add("@Birthdate", obj.Birthdate);

                    db.Query("UpdateCustomer", param, commandType: CommandType.StoredProcedure);
                    result = obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool DeleteCustomer(int id)
        {
            var result = false;

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdCustomer", id);

                    db.Query("DeleteCustomer", param, commandType: CommandType.StoredProcedure);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        #endregion

        #region Orders

        public Order CreateOrder(Order obj)
        {
            var result = new Order();

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@DateOrder", obj.DateOrder);
                    param.Add("@IdCustomer", obj.IdCustomer);

                    result = db.Query<Order>("CreateOrder", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }

                obj.OrderDetails.ForEach(x => x.IdOrder = result.IdOrder);
                UpdateOrderDetails(obj.OrderDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public List<Order> ReadOrder(int id)
        {
            var result = new List<Order>();

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdOrder", id);

                    result = db.Query<Order>("ReadOrder", param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public List<OrderDetail> ReadOrderDetail(int id)
        {
            var result = new List<OrderDetail>();

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdOrderDetail", id);

                    result = db.Query<OrderDetail>("ReadOrderDetail", param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public List<OrderDetail> ReadOrderDetailByIdOrder(int idOrder)
        {
            var result = new List<OrderDetail>();

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdOrder", idOrder);

                    result = db.Query<OrderDetail>("ReadOrderDetailByIdOrder", param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public Order UpdateOrder(Order obj)
        {
            var result = new Order();

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdOrder", obj.IdOrder);
                    param.Add("@DateOrder", obj.DateOrder);
                    param.Add("@IdCustomer", obj.IdCustomer);

                    db.Query("UpdateOrder", param, commandType: CommandType.StoredProcedure);
                    result = obj;
                }

                obj.OrderDetails.ForEach(x => x.IdOrder = result.IdOrder);
                UpdateOrderDetails(obj.OrderDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public bool UpdateOrderDetails(List<OrderDetail> obj)
        {
            var result = false;

            try
            {
                if (DeleteOrderDetailsByIdOrder(obj.FirstOrDefault().IdOrder))
                {
                    foreach (var item in obj)
                    {
                        using (IDbConnection db = new SqlConnection(_connectionString))
                        {
                            var param = new DynamicParameters();
                            param.Add("@IdOrder", item.IdOrder);
                            param.Add("@IdProduct", item.IdProduct);
                            param.Add("@QuantityProducts", item.QuantityProducts);

                            db.Query("CreateOrderDetails", param, commandType: CommandType.StoredProcedure);
                        }
                    }

                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private bool DeleteOrderDetailsByIdOrder(int id)
        {
            var result = false;

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdOrder", id);

                    db.Query("DeleteOrderDetailsByIdOrder", param, commandType: CommandType.StoredProcedure);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool DeleteOrder(int id)
        {
            var result = false;

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdOrder", id);

                    db.Query("DeleteOrder", param, commandType: CommandType.StoredProcedure);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        #endregion

        #region Products

        public Product CreatetProduct(Product obj)
        {
            var result = new Product();

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@Name", obj.Name);
                    param.Add("@Cost", obj.Cost);
                    param.Add("@Code", obj.Code);
                    param.Add("@Description", obj.Description);

                    result = db.Query<Product>("CreatetProduct", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public List<Product> ReadProduct(int id)
        {
            var result = new List<Product>();

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdProduct", id);

                    result = db.Query<Product>("ReadProduct", param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public Product UpdateProduct(Product obj)
        {
            var result = new Product();

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdProduct", obj.IdProduct);
                    param.Add("@Name", obj.Name);
                    param.Add("@Cost", obj.Cost);
                    param.Add("@Code", obj.Code);
                    param.Add("@Description", obj.Description);

                    db.Query("UpdateProduct", param, commandType: CommandType.StoredProcedure);
                    result = obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool UpdateProductCategories(int id, List<int> obj)
        {
            var result = false;

            try
            {
                if (DeleteProductCategoriesByIdProduct(id))
                {
                    foreach (var item in obj)
                    {
                        using (IDbConnection db = new SqlConnection(_connectionString))
                        {
                            var param = new DynamicParameters();
                            param.Add("@IdProduct", id);
                            param.Add("@IdCategory", item);

                            db.Query("CreateProductCategories", param, commandType: CommandType.StoredProcedure);
                        }
                    }
                }

                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private bool DeleteProductCategoriesByIdProduct(int id)
        {
            var result = false;

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdProduct", id);

                    db.Query("DeleteProductCategoriesByIdProduct", param, commandType: CommandType.StoredProcedure);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool DeleteProduct(int id)
        {
            var result = false;

            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var param = new DynamicParameters();
                    param.Add("@IdProduct", id);

                    db.Query("DeleteProduct", param, commandType: CommandType.StoredProcedure);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        #endregion
    }
}
