using SannaCommerce.WebShop.Domain;
using SannaCommerce.WebShop.Domain.IApplication;
using SannaCommerce.WebShop.Presentation.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SannaCommerce.WebShop.Presentation.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IApplication _application;

        public OrdersController(IApplication application)
        {
            _application = application;
        }

        // GET: Orders
        public ActionResult Index()
        {
            var model = SessionManager.OrdersModel;
            var orders = _application.ReadOrder(0) ?? new List<Order>();
            model.Orders = model.Orders.Where(x => x.IdOrder == 0).ToList();
            model.Orders.AddRange(orders);
            model.Customers = _application.ReadCustomer(0) ?? new List<Customer>();

            return View(model);
        }

        public ActionResult New()
        {
            var model = new OrdersModel();

            model.Customers = _application.ReadCustomer(0) ?? new List<Customer>();
            model.Products = _application.ReadProduct(0) ?? new List<Product>();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(OrdersModel model)
        {
            var orders = SessionManager.OrdersModel.Orders;
            var detail = JsonConvert.DeserializeObject<List<OrderDetail>>(model.JsonOrderDetails);
            var newOrder = new Order()
            {
                IdCustomer = model.IdCustomer,
                DateOrder = model.DateOrder,
                OrderDetails = detail
            };
            orders.Add(newOrder);

            model = new OrdersModel();
            model.Orders = orders;

            model.ToSave = true;

            SessionManager.OrdersModel = model;
            SessionManager.PendingChanges = true;
            SessionManager.CancelChanges = false;

            return Redirect("~/Orders");
        }

        public ActionResult Edit(int id)
        {
            var model = new OrdersModel();

            var order = _application.ReadOrder(id).FirstOrDefault();
            model.IdOrder = order.IdOrder;
            model.IdCustomer = order.IdCustomer;
            model.DateOrder = order.DateOrder;
            model.OrderDetails = _application.ReadOrderDetailByIdOrder(model.IdOrder);
            model.Customers = _application.ReadCustomer(0) ?? new List<Customer>();
            model.Products = _application.ReadProduct(0) ?? new List<Product>();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrdersModel model)
        {
            var detail = JsonConvert.DeserializeObject<List<OrderDetail>>(model.JsonOrderDetails);
            var order = new Order()
            {
                IdOrder = model.IdOrder,
                IdCustomer = model.IdCustomer,
                DateOrder = model.DateOrder,
                OrderDetails = detail
            };
            _application.UpdateOrder(order);

            return Redirect("~/Orders");
        }

        public ActionResult Delete(int id)
        {
            var model = new OrdersModel();

            var order = _application.ReadOrder(id).FirstOrDefault();
            model.IdOrder = order.IdOrder;
            model.IdCustomer = order.IdCustomer;
            model.DateOrder = order.DateOrder;
            model.Customers = _application.ReadCustomer(order.IdCustomer);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(OrdersModel model)
        {
            _application.DeleteOrder(model.IdOrder);

            return Redirect("~/Orders");
        }

        public ActionResult Detail(int id)
        {
            var model = new OrdersModel();

            model.OrderDetails = _application.ReadOrderDetailByIdOrder(id);
            model.Products = _application.ReadProduct(0) ?? new List<Product>();

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveChanges()
        {
            var model = SessionManager.OrdersModel;

            foreach (var item in model.Orders.Where(x => x.IdOrder == 0))
            {
                _application.CreateOrder(item);
            }

            SessionManager.OrdersModel = new OrdersModel();
            SessionManager.CancelChanges = SessionManager.ValidateEmptySessionModels();

            return Redirect("~/Orders");

        }
    }
}