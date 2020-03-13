using Application.Commands.CategoryCommands;
using Application.Commands.ManufacturerCommands;
using Application.Commands.ProductCommands;
using Application.Commands.SupplierCommands;
using EfCommands.CategoryCommands;
using EfCommands.ManufacturerCommands;
using EfCommands.ProductCommands;
using EfCommands.SupplierCommands;
using EfDataAccess;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace MVC
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(Container);
        }

        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterInstance<IDbConnection>(new SqlConnection(@"Data Source=MLADEN\SQLEXPRESS;Initial Catalog=WMDB;User ID=sa;Password=kJAGHr2w"));
            container.RegisterType<DbContext, WmContext>();

            container.RegisterType<IGetProductCommand, EfGetProductCommand>();
            container.RegisterType<IGetInsertUpdateProductCommand, EfGetInsertUpdateProductCommand>();
            container.RegisterType<IGetProductsCommand, EfGetProductsCommand>();
            container.RegisterType<IAddProductCommand, EfAddProductCommand>();
            container.RegisterType<IEditProductCommand, EfEditProductCommand>();
            container.RegisterType<IDeleteProductSuppliersCommand, EfDeleteProductSuppliersCommand>();

            container.RegisterType<IGetCategoriesCommand, EfGetCategoriesCommand>();
            container.RegisterType<IGetManufacturersCommand, EfGetManufacturersCommand>();
            container.RegisterType<IGetSuppliersCommand, EfGetSuppliersCommand>();
        }
    }
}