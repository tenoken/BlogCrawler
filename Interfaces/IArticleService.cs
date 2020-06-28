using BlogCrawler.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Interfaces
{
    public interface IArticleService
    {
        string GetPageTitle();

        string GetCurrentUrl();

        List<string> GetArticlesId();

        List<Article> GetNextPage();

        List<Article> GetPreviousPage();

        List<Article> GetArticleContent();

        void AddComment(Article article, Comment comment);
    }
}
