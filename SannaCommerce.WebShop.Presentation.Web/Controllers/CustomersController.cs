using SannaCommerce.WebShop.Domain;
using SannaCommerce.WebShop.Domain.IApplication;
using SannaCommerce.WebShop.Presentation.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SannaCommerce.WebShop.Presentation.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IApplication _application;

        public CustomersController(IApplication application)
        {
            _application = application;
        }

        // GET: Customers
        public ActionResult Index()
        {
            var model = SessionManager.CustomersModel;
            var customers = _application.ReadCustomer(0) ?? new List<Customer>();
            model.Customers = model.Customers.Where(x => x.IdCustomer == 0).ToList();
            model.Customers.AddRange(customers);

            return View(model);
        }
        
        public ActionResult New()
        {
            var model = new CustomersModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(CustomersModel model)
        {
            var customers = SessionManager.CustomersModel.Customers;
            var newCustomer = new Customer()
            {
                Name = model.Name,
                Phone = model.Phone,
                Address = model.Address,
                Email = model.Email,
                Birthdate = model.Birthdate
            };
            customers.Add(newCustomer);

            model = new CustomersModel();
            model.Customers = customers;
            model.ToSave = true;            

            SessionManager.CustomersModel = model;
            SessionManager.PendingChanges = true;
            SessionManager.CancelChanges = false;

            return Redirect("~/Customers");
        }

        public ActionResult Edit(int id)
        {
            var model = new CustomersModel();

            var customer = _application.ReadCustomer(id).FirstOrDefault();
            model.IdCustomer = customer.IdCustomer;
            model.Name = customer.Name;
            model.Phone = customer.Phone;
            model.Address = customer.Address;
            model.Email = customer.Email;
            model.Birthdate = customer.Birthdate;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomersModel model)
        {
            var customer = new Customer()
            {
                IdCustomer = model.IdCustomer,
                Name = model.Name,
                Phone = model.Phone,
                Address = model.Address,
                Email = model.Email,
                Birthdate = model.Birthdate,
            };
            _application.UpdateCustomer(customer);

            return Redirect("~/Customers");
        }

        public ActionResult Delete(int id)
        {
            var model = new CustomersModel();

            var customer = _application.ReadCustomer(id).FirstOrDefault();
            model.IdCustomer = customer.IdCustomer;
            model.Name = customer.Name;
            model.Phone = customer.Phone;
            model.Address = customer.Address;
            model.Email = customer.Email;
            model.Birthdate = customer.Birthdate;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomersModel model)
        {
            _application.DeleteCustomer(model.IdCustomer);

            return Redirect("~/Customers");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveChanges()
        {
            var model = SessionManager.CustomersModel;

            foreach (var item in model.Customers.Where(x => x.IdCustomer == 0))
            {
                _application.CreatetCustomer(item);
            }

            SessionManager.CustomersModel = new CustomersModel();
            SessionManager.CancelChanges = SessionManager.ValidateEmptySessionModels();

            return Redirect("~/Customers");
        }
    }
}