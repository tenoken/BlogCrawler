using BlogCrawler.Class.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Class
{
    public class HomePage : Page, IDisposable
    {
        private readonly string _name;
        private readonly List<Article> _articlesList;

        public string Name { get { return _name; } }

        public HomePage(string name, List<Article> articlesList) : base(name, articlesList)
        {
            _name = name;            
            _articlesList = articlesList;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
