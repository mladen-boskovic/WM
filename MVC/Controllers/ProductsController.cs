using Application.Commands.CategoryCommands;
using Application.Commands.ManufacturerCommands;
using Application.Commands.ProductCommands;
using Application.Commands.SupplierCommands;
using Application.DTOs.InsertUpdateDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IGetProductCommand _getProduct;
        private readonly IGetProductsCommand _getProducts;
        private readonly IAddProductCommand _addProduct;

        private readonly IGetCategoriesCommand _getCategories;
        private readonly IGetManufacturersCommand _getManufacturers;
        private readonly IGetSuppliersCommand _getSuppliers;

        public ProductsController(IGetProductCommand getProduct, IGetProductsCommand getProducts, IAddProductCommand addProduct, IGetCategoriesCommand getCategories, IGetManufacturersCommand getManufacturers, IGetSuppliersCommand getSuppliers)
        {
            _getProduct = getProduct;
            _getProducts = getProducts;
            _addProduct = addProduct;
            _getCategories = getCategories;
            _getManufacturers = getManufacturers;
            _getSuppliers = getSuppliers;
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = _getProducts.Execute();
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var product = _getProduct.Execute(id);
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.Manufacturers = new SelectList(_getManufacturers.Execute(), "ManufacturerId", "Name");
            ViewBag.Categories = new SelectList(_getCategories.Execute(), "CategoryId", "Name");
            ViewBag.Suppliers = new SelectList(_getSuppliers.Execute(), "SupplierId", "Name");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(InsertUpdateProductDto product)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    ViewBag.Manufacturers = new SelectList(_getManufacturers.Execute(), "ManufacturerId", "Name");
                    ViewBag.Categories = new SelectList(_getCategories.Execute(), "CategoryId", "Name");
                    ViewBag.Suppliers = new SelectList(_getSuppliers.Execute(), "SupplierId", "Name");
                    return View(product);
                }

                _addProduct.Execute(product);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Manufacturers = new SelectList(_getManufacturers.Execute(), "ManufacturerId", "Name");
                ViewBag.Categories = new SelectList(_getCategories.Execute(), "CategoryId", "Name");
                ViewBag.Suppliers = new SelectList(_getSuppliers.Execute(), "SupplierId", "Name");
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
