using System;
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

        public AuctionController(IAuctionRepository auctionRepository, IProductRepository productRepository)
        {
            this.repository = auctionRepository;
            this.productRepository = productRepository;
        }

        public ActionResult List()
        {
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
        public ActionResult DoEdit([Bind(Include = "Auction.AuctionId,Auction.Description,SelectedProductIds")] AuctionViewModel auctionViewModel)
        {
            if (!ModelState.IsValid)
                return View("Edit", new AuctionViewModel { Products = GetMultiselect(auctionViewModel.SelectedProductIds) });

            auctionViewModel.Auction.Owner = Session["user"] as User;

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

            if (auctionViewModel.Auction.Id <= 0)
            {
                auctionViewModel.Auction.CreationDate = DateTime.Now;
                repository.Add(auctionViewModel.Auction);
            }
            else
            {
                repository.Save(auctionViewModel.Auction);
            }

            return RedirectToAction("List");
        }

        private MultiSelectList GetMultiselect(List<int> ids = null)
        {
            if (ids == null)
                return new MultiSelectList(productRepository.Products.OrderBy(i => i.Name), "ProductId", "Name");

            return new MultiSelectList(productRepository.Products.OrderBy(i => i.Name), "ProductId", "Name", ids);
        }

        private List<int> GetSelectedIds(Auction auction)
        {
            return productRepository.Products.Where(p => p.Auctions.Contains(auction)).Select(p => p.Id).ToList();
        }
    }
}