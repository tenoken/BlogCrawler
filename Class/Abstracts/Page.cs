using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Class.Abstracts
{
    public abstract class Page
    {
        private readonly List<Article> _articlesList;

        public List<Article> ArticlesList => _articlesList;

        public Page(string title, List<Article> articlesList)
        {
            _articlesList = articlesList;
        }

    }
}
