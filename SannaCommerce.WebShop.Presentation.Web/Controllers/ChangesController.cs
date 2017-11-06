using SannaCommerce.WebShop.Presentation.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SannaCommerce.WebShop.Presentation.Web.Controllers
{
    public class ChangesController : Controller
    {
        [HttpPost]
        public ActionResult Cancel()
        {
            SessionManager.CancelChanges = true;
            SessionManager.PendingChanges = false;
            SessionManager.CategoriesModel = new CategoriesModel();
            SessionManager.CustomersModel = new CustomersModel();
            SessionManager.OrdersModel = new OrdersModel();
            SessionManager.ProductsModel = new ProductsModel();

            return Redirect("~/");
        }

        [HttpPost]
        public JsonResult UpdateCategoriesModel(string jsonObject)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<CategoriesModel>(jsonObject);
                SessionManager.CategoriesModel = model;
                SessionManager.PendingChanges = true;

                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public JsonResult UpdateCustomersModel(string jsonObject)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<CustomersModel>(jsonObject);
                SessionManager.CustomersModel = model;
                SessionManager.PendingChanges = true;

                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }

        }

        [HttpPost]
        public JsonResult UpdateOrdersModel(string jsonObject)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<OrdersModel>(jsonObject);
                SessionManager.OrdersModel = model;
                SessionManager.PendingChanges = true;

                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }

        }

        [HttpPost]
        public JsonResult UpdateProductsModel(string jsonObject)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<ProductsModel>(jsonObject);
                SessionManager.ProductsModel = model;
                SessionManager.PendingChanges = true;

                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }

        }
    }
}