using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using GameStore.WebUI.Models;

namespace GameStore.WebUI.Controllers
{
    public class OfferController : Controller
    {
        private IOfferRepository repository;
        private IAuctionRepository auctionRepository;
        private IProductRepository productRepository;
        private IUserRepository userRepository;

        public OfferController(IOfferRepository repository, IAuctionRepository auctionRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.auctionRepository = auctionRepository;
            this.productRepository = productRepository;
            this.userRepository = userRepository; ;
        }

        // GET: Offer
        public ActionResult Add(Auction auction)
        {
            Session["au"] = auction;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,Owner,Price,Accepted,Auction")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                var a = Session["au"] as Auction;
                a.Owner = Session["User"] as User;
                offer.Auction = a;
                offer.Owner = offer.Auction.Owner;
                repository.Add(offer);
                return RedirectToAction("Details", "Auction", new { id = a.Id } );
            }
            return View();
        }
        public ActionResult List()
        {
            return View(repository.Offers);
        }
    }
}