﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using GameStore.WebUI.Models;

namespace GameStore.WebUI.Controllers
{
    public class AuctionController : Controller
    {
        // GET: Auction
        private IAuctionRepository repository;
        private IProductRepository productRepository;
        private IUserRepository userRepository;

        public AuctionController(IAuctionRepository auctionRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            this.repository = auctionRepository;
            this.productRepository = productRepository;
            this.userRepository = userRepository;;
        }

        public ActionResult List()
        {
            var user = Session["User"] as User;
            if(user == null)
                return RedirectToAction("Login", "Login");
            return View(repository.Auctions);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction auction = repository.Find(id);
            if (auction == null)
            {
                return HttpNotFound();
            }
            return View(auction);
        }

        // GET: /Audtion/Add
        public ActionResult Add()
        {
            return View("Edit", new AuctionViewModel { Products = GetMultiselect() });
        }

        // GET: /Product/Edit/:id
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Auction auction = repository.Find(id);

            if (auction == null)
            {
                return HttpNotFound();
            }

            return View(new AuctionViewModel { Products = GetMultiselect(GetSelectedIds(auction)) });
        }

        // POST: /Product/Edit/:id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoEdit([Bind(Include = "Auction,SelectedProductIds")] AuctionViewModel auctionViewModel)
        {
            if (!ModelState.IsValid)
                return View("Edit", new AuctionViewModel { Products = GetMultiselect(auctionViewModel.SelectedProductIds) });

            if (Session["UserId"] == null) throw new Exception("Current user is null");
            int currentUser = (int)Session["UserId"];

            auctionViewModel.Auction.Owner = userRepository.Find(currentUser);

            foreach (var product in auctionViewModel.SelectedProductIds.Select(productId => productRepository.Find(productId)))
            {
                if (product != null)
                {
                    auctionViewModel.Auction.Products.Add(product);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            auctionViewModel.Auction.CreationDate = DateTime.Now;
            repository.Save(auctionViewModel.Auction);

            return RedirectToAction("List");
        }

        private MultiSelectList GetMultiselect(List<int> ids = null)
        {
            if (ids == null)
                return new MultiSelectList(productRepository.Products.Where(i => i.OwnerLogin == Session["Login"] as String).OrderBy(i => i.Name), "Id", "Name");

            return new MultiSelectList(productRepository.Products.OrderBy(i => i.Name), "Id", "Name", ids);
        }

        private List<int> GetSelectedIds(Auction auction)
        {
            return productRepository.Products.Where(p => p.Auctions.Contains(auction)).Select(p => p.Id).ToList();
        }
    }
}