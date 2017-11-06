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
    public class ProductsController : Controller
    {
        private readonly IApplication _application;

        public ProductsController(IApplication application)
        {
            _application = application;
        }

        // GET: Products
        public ActionResult Index()
        {
            var model = SessionManager.ProductsModel;
            var products = _application.ReadProduct(0) ?? new List<Product>();
            model.Products = model.Products.Where(x => x.IdProduct == 0).ToList();
            model.Products.AddRange(products);

            return View(model);
        }

        public ActionResult New()
        {
            var model = new ProductsModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(ProductsModel model)
        {
            var products = SessionManager.ProductsModel.Products;
            var newProducts = new Product()
            {
                Name = model.Name,
                Code = model.Code,
                Cost = model.Cost,
                Description = model.Description
            };
            products.Add(newProducts);

            model = new ProductsModel();
            model.Products = products;
            model.ToSave = true;

            SessionManager.ProductsModel = model;
            SessionManager.PendingChanges = true;
            SessionManager.CancelChanges = false;

            return Redirect("~/Products");
        }

        public ActionResult Edit(int id)
        {
            var model = new ProductsModel();

            var product = _application.ReadProduct(id).FirstOrDefault();
            model.IdProduct = product.IdProduct;
            model.Name = product.Name;
            model.Cost = product.Cost;
            model.Code = product.Code;
            model.Description = product.Description;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductsModel model)
        {
            var products = new Product()
            {
                IdProduct = model.IdProduct,
                Name = model.Name,
                Cost = model.Cost,
                Code = model.Code,
                Description = model.Description
            };
            _application.UpdateProduct(products);

            return Redirect("~/Products");
        }

        public ActionResult Delete(int id)
        {
            var model = new ProductsModel();

            var product = _application.ReadProduct(id).FirstOrDefault();
            model.IdProduct = product.IdProduct;
            model.Name = product.Name;
            model.Cost = product.Cost;
            model.Code = product.Code;
            model.Description = product.Description;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductsModel model)
        {
            _application.DeleteProduct(model.IdProduct);

            return Redirect("~/Products");
        }
        
        public ActionResult Categories(int id)
        {
            var model = new ProductsModel();

            model.IdProduct = id;
            model.Categories = _application.ReadCategoryByIdProduct(model.IdProduct);
            model.AllCategories = _application.ReadCategory(0) ?? new List<Category>();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Categories(ProductsModel model)
        {
            _application.UpdateProductCategories(model.IdProduct, model.ProductCategories.ToList());

            return Redirect("~/Products");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveChanges()
        {
            var model = SessionManager.ProductsModel;

            foreach (var item in model.Products.Where(x => x.IdProduct == 0))
            {
                _application.CreatetProduct(item);
            }

            SessionManager.ProductsModel = new ProductsModel();
            SessionManager.CancelChanges = SessionManager.ValidateEmptySessionModels();

            return Redirect("~/Products");
        }
    }
}