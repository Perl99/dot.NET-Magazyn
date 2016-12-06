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
    public class ProductControllerTests
    {
        [TestMethod()]
        public void checkIsNullTest()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product { Id = 1, Price =2, Name = "Battlefield" }
            });
            var controler = new ProductController(mock.Object);

            bool result = controler.checkIsNull(mock.Object.Products.First());
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] { } );
            var controler = new ProductController(mock.Object);

            ActionResult result = controler.Details(2);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }
    }
}