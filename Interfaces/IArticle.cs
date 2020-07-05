using BlogCrawler.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Interfaces
{
    public interface IArticle
    {
        Article CreateArticle(string title, string overview, string link, Bitmap image = null);

        List<Article> CreateArticleList();
    }
}
