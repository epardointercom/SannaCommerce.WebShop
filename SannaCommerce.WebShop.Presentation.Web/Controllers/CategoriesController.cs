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
    public class CategoriesController : Controller
    {
        private readonly IApplication _application;

        public CategoriesController(IApplication application)
        {
            _application = application;
        }

        // GET: Categories
        public ActionResult Index()
        {
            var model = SessionManager.CategoriesModel;
            var categories = _application.ReadCategory(0) ?? new List<Category>();
            model.Categories = model.Categories.Where(x => x.IdCategory == 0).ToList();
            model.Categories.AddRange(categories);

            return View(model);
        }

        public ActionResult New()
        {
            var model = new CategoriesModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(CategoriesModel model)
        {
            var categories = SessionManager.CategoriesModel.Categories;
            var newCategory = new Category()
            {
                Name = model.Name,
                Code = model.Code,
                Description = model.Description
            };
            categories.Add(newCategory);

            model = new CategoriesModel();
            model.Categories = categories;
            model.ToSave = true;

            SessionManager.CategoriesModel = model;
            SessionManager.PendingChanges = true;
            SessionManager.CancelChanges = false;

            return Redirect("~/Categories");
        }

        public ActionResult Edit(int id)
        {
            var model = new CategoriesModel();

            var category = _application.ReadCategory(id).FirstOrDefault();
            model.IdCategory = category.IdCategory;
            model.Name = category.Name;
            model.Code = category.Code;
            model.Description = category.Description;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriesModel model)
        {
            var categories = new Category()
            {
                IdCategory = model.IdCategory,
                Name = model.Name,
                Code = model.Code,
                Description = model.Description
            };
            _application.UpdateCategory(categories);

            return Redirect("~/Categories");
        }

        public ActionResult Delete(int id)
        {
            var model = new CategoriesModel();

            var category = _application.ReadCategory(id).FirstOrDefault();
            model.IdCategory = category.IdCategory;
            model.Name = category.Name;
            model.Code = category.Code;
            model.Description = category.Description;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoriesModel model)
        {
            _application.DeleteCategory(model.IdCategory);

            return Redirect("~/Categories");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveChanges()
        {
            var model = SessionManager.CategoriesModel;

            foreach (var item in model.Categories.Where(x => x.IdCategory == 0))
            {
                _application.CreatetCategory(item);
            }

            SessionManager.CategoriesModel = new CategoriesModel();
            SessionManager.CancelChanges = SessionManager.ValidateEmptySessionModels();

            return Redirect("~/Categories");
        }
    }
}