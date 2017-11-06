using Microsoft.Practices.Unity;
using SannaCommerce.WebShop.Domain.IRepository;
using SannaCommerce.WebShop.Domain.IApplication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Unity.Mvc5;
using SannaCommerce.WebShop.Repository.Sql;

namespace SannaCommerce.WebShop.Tools.InjectFactory
{
    public class UnityStart
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new
            UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["sqlConnection"]?.ConnectionString ?? "";

            //********************//
            // Data Storage Inyect
            //********************//
            // SQL Data Storage
            container.RegisterType<IWebShopRepository, WebShopRepository>(new InjectionConstructor(
                connectionString));
            // CSV file Data Storage
            //container.RegisterType<IWebShopRepository, Repository.Csv.WebShopRepository>(new InjectionConstructor(
            //    connectionString));
            // Mongo no relational database Data Storage
            //container.RegisterType<IWebShopRepository, Repository.Mongo.WebShopRepository>(new InjectionConstructor(
            //    connectionString));
            // XML file Data Storage
            //container.RegisterType<IWebShopRepository, Repository.Xml.WebShopRepository>(new InjectionConstructor(
            //    connectionString));

            // Aplication Inyect
            container.RegisterType<IApplication, Application.Application>(new InjectionConstructor(
                 new ResolvedParameter<IWebShopRepository>()));
        }
    }
}
