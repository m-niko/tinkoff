using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tinkoff.DAL.Models;

namespace Tinkoff.Tests
{
    [TestClass]
    public class ShortenTest
    {
        [TestMethod]
        public void CreateShortenIsCorrect()
        {
            var rawUrl = "microsoft";
            var shorted = new Shorten(new DefaultShortedUrlGenerator(),  rawUrl);

            Assert.IsNotNull(shorted);
            Assert.AreEqual(rawUrl, shorted.RawUrl);
            Assert.AreEqual(0, shorted.TotalClicks);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateShortenWhitEmptyRawUrlThrowException()
        {
            var rawUrl = "";
            var shorted = new Shorten(new DefaultShortedUrlGenerator(),  rawUrl);
        }

        [TestMethod]
        public void ShortenIncreaseClickCountIsCorrect()
        {
            var rawUrl = "http://microsoft.com/ru/help";
            var shorted = new Shorten(new DefaultShortedUrlGenerator(), rawUrl);
            var totalClicks = shorted.TotalClicks;

            shorted.IncreaseClickCount();

            Assert.IsTrue(totalClicks < shorted.TotalClicks);
        }
    }
}
