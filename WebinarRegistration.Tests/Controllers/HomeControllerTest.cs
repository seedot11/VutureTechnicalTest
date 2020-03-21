using System;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using WebinarRegistration.Controllers;
using WebinarRegistration.Services;

namespace WebinarRegistration.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void IndexMethodRedirects()
        {
            var controller = new HomeController(_webinarServiceMock.Object);
            var result = controller.Index() as RedirectToRouteResult;

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void IndexRedirectRoutesCorrectly()
        {
            var controller = new HomeController(_webinarServiceMock.Object);
            var result = controller.Index() as RedirectToRouteResult;

            Assert.That(result.RouteName, Is.EqualTo("Webinars by year"));
        }

        [Test]
        public void IndexRedirectToCurrentYear()
        {
            var controller = new HomeController(_webinarServiceMock.Object);
            var result = controller.Index() as RedirectToRouteResult;

            Assert.That(result.RouteValues["year"], Is.EqualTo(DateTime.UtcNow.Year));
        }

        [Test]
        public void IndexRedirectIsNotPermanent()
        {
            var controller = new HomeController(_webinarServiceMock.Object);
            var result = controller.Index() as RedirectToRouteResult;

            Assert.That(result.Permanent, Is.False);
        }

        [Test]
        [TestCase(1985), TestCase(2016), TestCase(3032)]
        public void WebinarMethodStoresViewBag(int testData)
        {
            var controller = new HomeController(_webinarServiceMock.Object);
            var result = controller.Webinars(testData) as ViewResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ViewBag.year as int?, Is.EqualTo(testData));
        }

        [Test]
        [TestCase(1985), TestCase(2016), TestCase(3032)]
        public void WebinarMethodCallsRepository(int testData)
        {
            var controller = new HomeController(_webinarServiceMock.Object);
            
            Assert.DoesNotThrow(() => controller.Webinars(testData));

            _webinarServiceMock.Verify(x => x.GetWebinarsByYear(testData), Times.Once);
        }

        [SetUp]
        public void CreateMocks()
        {
            _webinarServiceMock = new Mock<IWebinarService>();
        }

        private Mock<IWebinarService> _webinarServiceMock;
    }
}
