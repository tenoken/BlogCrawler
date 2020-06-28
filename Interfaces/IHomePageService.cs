using BlogCrawler.Class;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Interfaces
{
    public interface IHomePageService 
    {
        HomePage CreateHomePage(string title, List<Article> articles);
    }
}
