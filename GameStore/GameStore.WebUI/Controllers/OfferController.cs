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
            Session["auction"] = auction;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,Owner,Price,Accepted,Auction")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                offer.Owner = Session["User"] as User;
                repository.Add(offer);
                var au = Session["auction"] as Auction;
                Auction a = auctionRepository.Find(au.Id);
                a.Offers.Add(offer);
                auctionRepository.Save(a);
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