using BlogCrawler.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Class
{
    public class Article : IArticle, IDisposable
    {
        private readonly string _title;
        private readonly string _overview;
        private readonly string _link;
        private readonly Bitmap _image;
        private List<Comment> _commentsList;

        private bool _disposed = false;

        public string Title { get { return _title; } }
        public string Overview { get { return _overview; } }
        public string Link { get { return _link; } }
        public Bitmap Image { get { return _image; }}

        public List<Comment> CommentsList { get => _commentsList; }

        public Article(string title, string overview, string link, Bitmap image = null)
        {
            _title = title;
            _overview = overview;
            _link = link;
            _image = image;
            _commentsList = new List<Comment>();
        }

        public Article CreateArticle(string title, string overview, string link, Bitmap image = null)
        {
            return new Article(title, overview, link, image);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

            if (!this._disposed)
            {

                if (disposing)
                {
                    //this.Dispose();
                    _disposed = true;
                }
            }
        }

        public List<Article> CreateArticleList()
        {
            List<Article> articlesList = new List<Article>();
            return articlesList;
        }
    }
}
