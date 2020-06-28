using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Class.Abstracts
{
    public abstract class Report
    {
        private readonly List<Article> _articlesList;

        public Report(List<Article> articlesList)
        {
            _articlesList = articlesList;
        }
    }
}
