using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using System.Threading.Tasks;
using BlogCrawler.Class;
using System.Drawing;
using BlogCrawler.Interfaces;

namespace BlogCrawler.Crawler
{
    public class HomePageService : IHomePageService, IDisposable
    {
        bool disposed;

        private readonly IArticleService _articleService;

        public HomePageService(IArticleService articleService)
        {
            _articleService = articleService;
        }

        //public string GetPageTitle()
        //{
        //    return _articleService.GetPageTitle();
        //}

        //public string GetCurrentUrl()
        //{
        //    return _articleService.GetCurrentUrl();
        //}

        //public void AddComment(Article article ,Comment comment)
        //{
        //    article.CommentsList.Add(comment);
        //}

        public HomePage CreateHomePage(string title, List<Article> articles)
        {
            return new HomePage(title, articles);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }
    }
}
