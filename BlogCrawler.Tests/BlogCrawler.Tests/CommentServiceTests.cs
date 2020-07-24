using BlogCrawler.Class;
using BlogCrawler.Driver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace BlogCrawler.Tests
{
    [TestClass]
    class CommentServiceTests
    {

        [Test]
        public void ShouldCreateRandomCommentsWihtCountEqualTo20()
        {
            var sut = new CommentService(new Comment("", "", "", "", ""));

            var result = sut.CreateRandomComments();

            Assert.That(result.Count, Is.EqualTo(20));
        }


        [Test]
        public void ShouldCreateRandomComments()
        {
            var sut = new CommentService(new Comment("", "", "", "", ""));

            var result = sut.CreateRandomComments();

            Assert.That(result, Is.All.TypeOf<Comment>());
        }

        //TODO: Must implement invalid operation exception to test this method

        //[Test]
        //public void ShouldPostComment()
        //{
        //    var sut = new CommentService(new Comment("", "", "", "", ""));

        //    var result = sut.PostComment();

        //}
    }
}
