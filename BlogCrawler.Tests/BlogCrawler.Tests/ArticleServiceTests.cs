using System;
using BlogCrawler.Class;
using BlogCrawler.Driver;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BlogCrawler.Tests
{
    [TestFixture]
    public class ArticleServiceTests
    {
        [Test]
        public void ShouldGetPageTitle()
        {
            var sut = new ArticleService(new Article("","",""));

            var result = sut.GetPageTitle();

            Assert.That(result, Is.EqualTo("Japão em Foco - Curiosidades e Cultura Japonesa"));
        }

        [Test]
        public void ShouldGetCurrentUrl()
        {
            var sut = new ArticleService(new Article("", "", ""));

            var result = sut.GetCurrentUrl();

            Assert.That(result, Is.EqualTo("https://japaoemfoco.com/page/1"));
        }

        [Test]
        public void ShouldGetArticlesId()
        {
            var sut = new ArticleService(new Article("", "", ""));

            var result = sut.GetArticlesId();

            Assert.That(result, Is.All.TypeOf<string>());
        }

        [Test]
        public void ShouldGetArticleContent()
        {
            var sut = new ArticleService(new Article("", "", ""));

            var result = sut.GetArticleContent();

            Assert.That(result, Is.All.TypeOf<Article>());
        }

        [Test]
        public void ShouldGetNextPage()
        {
            var sut = new ArticleService(new Article("", "", ""));

            var result = sut.GetNextPage();

            Assert.That(result, Is.All.TypeOf<Article>());
        }

        [Test]
        public void ShouldGetPreviousPage()
        {
            var sut = new ArticleService(new Article("", "", ""));

            var result = sut.GetPreviousPage();

            Assert.That(result, Is.All.TypeOf<Article>());
        }

        [Test]
        public void ShouldGetArticleListCount()
        {
            var sut = new ArticleService(new Article("", "", ""));

            var result = sut.GetArticleContent();

            Assert.That(result.Count, Is.EqualTo(20));
        }
    }
}
