﻿using Application.Commands.CategoryCommands;
using Application.Commands.ManufacturerCommands;
using Application.Commands.ProductCommands;
using Application.Commands.SupplierCommands;
using Application.DTOs.InsertUpdateDTOs;
using Application.Exceptions;
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
        private readonly IGetInsertUpdateProductCommand _getInsertUpdateProduct;
        private readonly IGetProductsCommand _getProducts;
        private readonly IAddProductCommand _addProduct;
        private readonly IEditProductCommand _editProduct;

        private readonly IGetCategoriesCommand _getCategories;
        private readonly IGetManufacturersCommand _getManufacturers;
        private readonly IGetSuppliersCommand _getSuppliers;

        private readonly IGetProductsFromJsonCommand _getProductsFromJson;

        public ProductsController(IGetProductCommand getProduct, IGetInsertUpdateProductCommand getInsertUpdateProduct, IGetProductsCommand getProducts, IAddProductCommand addProduct, IEditProductCommand editProduct, IGetCategoriesCommand getCategories, IGetManufacturersCommand getManufacturers, IGetSuppliersCommand getSuppliers, IGetProductsFromJsonCommand getProductsFromJson)
        {
            _getProduct = getProduct;
            _getInsertUpdateProduct = getInsertUpdateProduct;
            _getProducts = getProducts;
            _addProduct = addProduct;
            _editProduct = editProduct;
            _getCategories = getCategories;
            _getManufacturers = getManufacturers;
            _getSuppliers = getSuppliers;
            _getProductsFromJson = getProductsFromJson;
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = _getProducts.Execute();
            return View(products);
        }

        public ActionResult IndexFromJson()
        {
            var products = _getProductsFromJson.Execute();
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var product = _getProduct.Execute(id);
            if(product == null)
            {
                return RedirectToAction("Index");
            }
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
            catch (EntityAlreadyExistsException e)
            {
                ViewBag.Manufacturers = new SelectList(_getManufacturers.Execute(), "ManufacturerId", "Name");
                ViewBag.Categories = new SelectList(_getCategories.Execute(), "CategoryId", "Name");
                ViewBag.Suppliers = new SelectList(_getSuppliers.Execute(), "SupplierId", "Name");
                TempData["error"] = e.Message;
                return View(product);
            }
            catch
            {
                ViewBag.Manufacturers = new SelectList(_getManufacturers.Execute(), "ManufacturerId", "Name");
                ViewBag.Categories = new SelectList(_getCategories.Execute(), "CategoryId", "Name");
                ViewBag.Suppliers = new SelectList(_getSuppliers.Execute(), "SupplierId", "Name");
                TempData["error"] = "An error has occured";
                return View(product);
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _getInsertUpdateProduct.Execute(id);
            if(product == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Manufacturers = new SelectList(_getManufacturers.Execute(), "ManufacturerId", "Name");
            ViewBag.Categories = new SelectList(_getCategories.Execute(), "CategoryId", "Name");
            ViewBag.Suppliers = _getSuppliers.Execute();

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(InsertUpdateProductDto product)
        {
            try
            {
                _editProduct.Execute(product);
                return RedirectToAction("Index");
            }
            catch (EntityAlreadyExistsException e)
            {
                ViewBag.Manufacturers = new SelectList(_getManufacturers.Execute(), "ManufacturerId", "Name");
                ViewBag.Categories = new SelectList(_getCategories.Execute(), "CategoryId", "Name");
                ViewBag.Suppliers = _getSuppliers.Execute();
                TempData["error"] = e.Message;
                return View(product);
            }
            catch
            {
                ViewBag.Manufacturers = new SelectList(_getManufacturers.Execute(), "ManufacturerId", "Name");
                ViewBag.Categories = new SelectList(_getCategories.Execute(), "CategoryId", "Name");
                ViewBag.Suppliers = _getSuppliers.Execute();
                TempData["error"] = "An error has occured";
                return View(product);
            }
        }
    }
}
