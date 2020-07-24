using BlogCrawler.Class;
using BlogCrawler.Driver;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Tests
{
    [TestFixture]
    class CSVReportServiceTests
    {
        private string _path;

        [Test]
        public void ShouldCreateCSVReport()
        {
            var sut = new ArticleService(new Article("", "", ""));

            var sut2 = new CSVReportService();

            _path = @"D:\Projects\WebScraping\WebScrapingDemo\WebScrapingDemo\Relatorios\";

            Assert.That(() => sut2.CreateReport(new List<Article>(), _path), Throws.Nothing);
        }

        [Test]
        public void ShouldThrowArgumentException()
        {
            var sut = new ArticleService(new Article("", "", ""));

            var sut2 = new CSVReportService();

            _path = "\test";

            Assert.That(() => sut2.CreateReport(new List<Article>(), _path), Throws.ArgumentException);
        }

        [Test]
        public void ShouldThrowArgumentNullException()
        {
            var sut = new ArticleService(new Article("", "", ""));

            var sut2 = new CSVReportService();

            Assert.That(() => sut2.CreateReport(new List<Article>(), null), Throws.ArgumentNullException);
        }

        [Test]
        public void ShouldThrowDirectoryNotFoundException()
        {
            var sut = new ArticleService(new Article("", "", ""));

            var sut2 = new CSVReportService();

            _path = @"D:\ThereIsNoReferencedPathHere\";

            Assert.That(() => sut2.CreateReport(new List<Article>(), _path), Throws.TypeOf<DirectoryNotFoundException>());
        }

        [Test]
        public void ShouldThrowGenericException()
        {
            var sut = new ArticleService(new Article("", "", ""));

            var sut2 = new CSVReportService();

            _path = "@";

            Assert.That(() => sut2.CreateReport(new List<Article>(), _path), Throws.Exception);
        }
    }
}
