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
        private Auction _auction;

        public OfferController(IOfferRepository repository)
        {
            this.repository = repository;
        }

        // GET: Offer
        public ActionResult Add(Auction auction)
        {
            ViewBag.Au = auction;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,Owner,Price,Accepted,Auction")] Offer offer, Auction auction)
        {
            if (ModelState.IsValid)
            {
                offer.Auction = ViewBag.Au;
                offer.Owner = Session["User"] as User;
                repository.Add(offer);
                return RedirectToAction("List");
            }
            return View();
        }
        public ActionResult List()
        {
            return View(repository.Offers);
        }
    }
}