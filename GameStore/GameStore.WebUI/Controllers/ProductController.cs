﻿using System.Net;
using System.Web.Mvc;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using System.Collections;

namespace GameStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ActionResult List()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(repository.Products);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repository.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: /Product/Add
        public ActionResult Add()
        {
            return View("Edit", new Product());
        }

        // GET: /Product/Edit/:id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = repository.Find(id);

            if (checkIsNull(product))
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /Product/Edit/:id
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoEdit([Bind(Include = "Id,Name,Description,Price,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.OwnerLogin = Session["Login"] as string;
                repository.Save(product);
                return RedirectToAction("List");
            }
            return View("Edit", product);
        }
        public bool checkIsNull(Product product)
        {
            if (product == null)
                return true;
            return false;
        }
    }
}