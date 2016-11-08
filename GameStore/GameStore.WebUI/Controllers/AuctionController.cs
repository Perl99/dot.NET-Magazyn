using System.Net;
using System.Web.Mvc;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;

namespace GameStore.WebUI.Controllers
{
    public class AuctionController : Controller
    {
        // GET: Auction
        private IAuctionRepository repository;

        public AuctionController(IAuctionRepository auctionRepository)
        {
            this.repository = auctionRepository;
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
            return View("Edit", new Auction());
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
            return View(auction);
        }

        // POST: /Product/Edit/:id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoEdit([Bind(Include = "AuctionId,Products,Owner,Offers,CreationDate")] Auction auction)
        {
            if (ModelState.IsValid)
            {
                if (auction.AuctionId <= 0)
                {
                    repository.Add(auction);
                }
                else
                {
                    repository.Save(auction);
                }
                return RedirectToAction("List");
            }
            return View(auction);
        }
    }
}