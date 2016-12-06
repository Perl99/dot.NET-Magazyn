using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameStore.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;
using System.Web.Mvc;

namespace GameStore.WebUI.Controllers.Tests
{
    [TestClass()]
    public class OfferControllerTests
    {
        [TestMethod()]
        public void findByIdTest()
        {
            Mock<IAuctionRepository> moc = new Mock<IAuctionRepository>();
            moc.Setup(m => m.Auctions).Returns(new Auction[]
            {
                new Auction { Id = 3, Description = "Good staff" }
            });

            Mock<IOfferRepository> mock = new Mock<IOfferRepository>();
            mock.Setup(m => m.Offers).Returns(new Offer[]
            {
                new Offer { Id = 2, Price = 120, Accepted = true }
            });
            var controller = new OfferController(mock.Object, moc.Object);

            Offer o = controller.findById(1);
            Assert.IsNull(o);
        }
    }
}