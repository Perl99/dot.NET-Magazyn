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
    public class LoginControllerTests
    {
        [TestMethod()]
        public void RegisterTest()
        {
            Mock<IUserRepository> moc = new Mock<IUserRepository>();
            moc.Setup(m => m.Users).Returns(new User[] { });

            var controller = new LoginController(moc.Object);
            User a = new User();
            a.Id = 2;
            a.Login = "admin";
            a.Password = "good";
            ActionResult result = controller.Register(a);

            User b = moc.Object.Find(2);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}