using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Tinkoff.DAL.Models;
using Tinkoff.Web.Controllers;

namespace Tinkoff.Tests
{
    [TestClass]
    public class ShortenControllerTest
    {
        private Mock<IShortenRepository> shortenRepositoryMock = new Mock<IShortenRepository>();
        private string[] rawUrls = new[] { "microsoft.com" };

        [TestInitialize]
        public void SetUp()
        {
            var shortens = new List<Shorten>
            {
                new Shorten("microsoft.com"),
                new Shorten("lenta.ru"),
                new Shorten("habrahabr.ru")
            };
            
            shortenRepositoryMock.Setup(s => s.GetShortenUrlsAsync(It.IsAny<string[]>()))
                .Returns(Task.FromResult(shortens.Where(w => rawUrls.Contains(w.RawUrl)).ToList()));
        }

        [TestMethod]
        public async Task ShortenControllerGetIsCorrect()
        {
            var shortenController = new ShortenController(shortenRepositoryMock.Object);
            var shortedUrls = await shortenController.Get(rawUrls);

            Assert.IsNotNull(shortedUrls);
            Assert.AreEqual(1, shortedUrls.Count);
        }

        [TestMethod]

        public async Task ShortenControllerCreateIsCorrect()
        {
            var shortenController = new ShortenController(shortenRepositoryMock.Object);
            var shortedUrls = await shortenController.Create("tk.com");

            shortenRepositoryMock.Verify(v=>v.SaveAsync(shortedUrls), Times.Once);
            Assert.IsNotNull(shortedUrls);
            Assert.AreEqual("tk.com", shortedUrls.RawUrl);
        }
    }
}
