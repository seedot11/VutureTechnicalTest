using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using WebinarRegistration.Repo;
using WebinarRegistration.Services;
using WebinarRegistration.Tests.Mocks;

namespace WebinarRegistration.Tests.Services
{
    [TestFixture]
    public class RepositoryServiceTests
    {
        [Test]
        public void CanWeMockDbContext()
        {
            var webinarService = GenerateWebinarService();
            Assert.DoesNotThrow(() => webinarService.GetWebinarsByYear(DateTime.UtcNow.Year));
        }

        [Test]
        public void WhereStatementWorks()
        {
            var webinarService = GenerateWebinarService();
            var output = webinarService.GetWebinarsByYear(DateTime.UtcNow.Year).ToArray();

            Assert.That(output.Length, Is.EqualTo(1));
        }

        private static WebinarService GenerateWebinarService()
        {
            var mockContext = new Mock<WebinarRegistrationEntities>();
            mockContext.Setup(x => x.Webinars).ReturnsDbSet(FakeWebinars());

            var webinarService = new WebinarService(mockContext.Object);
            return webinarService;
        }

        #region Test data
        private static Webinar[] FakeWebinars()
        {
            return new[]
            {
                new Webinar {Id = 1, Date = DateTime.UtcNow, Year = DateTime.UtcNow.Year},
                new Webinar {Id = 2, Date = new DateTime(1985, 1, 2), Year = 1985}
            };
        }
        #endregion
    }
}
