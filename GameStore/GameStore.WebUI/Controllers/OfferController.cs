using System.Web.Mvc;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;

namespace GameStore.WebUI.Controllers
{
    public class OfferController : Controller
    {
        private IOfferRepository repository;
        private IAuctionRepository auctionRepository;

        public OfferController(IOfferRepository repository, IAuctionRepository auctionRepository)
        {
            this.repository = repository;
            this.auctionRepository = auctionRepository;
        }

        // GET: Offer
        public ActionResult Add(Auction auction)
        {
            Session["auction"] = auction;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id,Owner,Price,Accepted")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                offer.Owner = Session["User"] as User;
                offer.Accepted = false;
                repository.Save(offer);
                var au = Session["auction"] as Auction;
                Auction a = auctionRepository.Find(au.Id);
                offer.Auction = a;
                a.Offers.Add(offer);
                auctionRepository.Save(a);
                return RedirectToAction("Details", "Auction", new { id = a.Id } );
            }
            return View();
        }
        public ActionResult List()
        {
            var user = Session["User"] as User;
            if (user == null)
                return RedirectToAction("Login", "Login");
            if (!user.Type)
                return RedirectToAction("List", "Auction");
            return View(repository.Offers);
        }
        public ActionResult Accept(int? id)
        {
            Offer offer = repository.Find(id);
            offer.Accepted = true;
            repository.Save(offer);
            Auction auction = auctionRepository.Find(offer.Auction.Id);
            foreach(Offer a in auction.Offers)
            {
                a.Accepted = (a.Id == id);
            }
            auctionRepository.Save(auction);
            return RedirectToAction("Details", "Auction", new { id = auction.Id });
        }
    }
}