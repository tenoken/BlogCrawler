using BlogCrawler.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Class
{
    public class Article : IDisposable
    {
        private readonly string _title;
        private readonly string _overview;
        private readonly string _link;
        private readonly Bitmap _image;
        private List<Comment> _commentsList;

        public string Title { get { return _title; } }
        public string Overview { get { return _overview; } }
        public string Link { get { return _link; } }
        public Bitmap Image { get { return _image; }}

        public List<Comment> CommentsList { get => _commentsList; set => _commentsList = value; }

        public Article(string title, string overview, string link, Bitmap image = null)
        {
            _title = title;
            _overview = overview;
            _link = link;
            _image = image;
            _commentsList = new List<Comment>();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
