using SannaCommerce.WebShop.Presentation.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SannaCommerce.WebShop.Presentation.Web
{
    public class SessionManager
    {
        public static bool PendingChanges
        {
            get
            {
                if (HttpContext.Current.Session["PendingChanges"] == null)
                {
                    HttpContext.Current.Session["PendingChanges"] = false;
                }
                return (bool)(HttpContext.Current.Session["PendingChanges"]);
            }
            set
            {
                HttpContext.Current.Session["PendingChanges"] = value;
            }
        }

        public static bool CancelChanges
        {
            get
            {
                if (HttpContext.Current.Session["CancelChanges"] == null)
                {
                    HttpContext.Current.Session["CancelChanges"] = false;
                }
                return (bool)(HttpContext.Current.Session["CancelChanges"]);
            }
            set
            {
                HttpContext.Current.Session["CancelChanges"] = value;
            }
        }

        public static bool ValidateEmptySessionModels()
        {
            if(CategoriesModel.ToSave || CustomersModel.ToSave || OrdersModel.ToSave || ProductsModel.ToSave)
            {
                return false;
            }
            else
            {
                PendingChanges = false;
                return true;
            }
        }

        public static CategoriesModel CategoriesModel
        {
            get
            {
                if (HttpContext.Current.Session["CategoriesModel"] == null)
                {
                    HttpContext.Current.Session["CategoriesModel"] = new CategoriesModel();
                }
                return (CategoriesModel)(HttpContext.Current.Session["CategoriesModel"]);
            }
            set
            {
                HttpContext.Current.Session["CategoriesModel"] = value;
            }
        }

        public static CustomersModel CustomersModel
        {
            get
            {
                if (HttpContext.Current.Session["CustomersModel"] == null)
                {
                    HttpContext.Current.Session["CustomersModel"] = new CustomersModel();
                }
                return (CustomersModel)(HttpContext.Current.Session["CustomersModel"]);
            }
            set
            {
                HttpContext.Current.Session["CustomersModel"] = value;
            }
        }

        public static OrdersModel OrdersModel
        {
            get
            {
                if (HttpContext.Current.Session["OrdersModel"] == null)
                {
                    HttpContext.Current.Session["OrdersModel"] = new OrdersModel();
                }
                return (OrdersModel)(HttpContext.Current.Session["OrdersModel"]);
            }
            set
            {
                HttpContext.Current.Session["OrdersModel"] = value;
            }
        }

        public static ProductsModel ProductsModel
        {
            get
            {
                if (HttpContext.Current.Session["ProductsModel"] == null)
                {
                    HttpContext.Current.Session["ProductsModel"] = new ProductsModel();
                }
                return (ProductsModel)(HttpContext.Current.Session["ProductsModel"]);
            }
            set
            {
                HttpContext.Current.Session["ProductsModel"] = value;
            }
        }
    }
}