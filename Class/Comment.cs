using BlogCrawler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Class
{
    public class Comment : IDisposable
    {
        private string _firstName;
        private string _lastName;
        private string _commentText;
        private string _emailSufix;
        private string _emailNumber;

        private Random random = new Random();


        public Comment(string firstName, string lastName, string emailNumber, string emailSufix, string commentText)
        {
            _firstName = firstName;
            _lastName = lastName;
            _emailSufix = emailSufix;
            _emailNumber = emailNumber;
            _commentText = commentText;
        }

        public string FirstName { get => _firstName; private set => _firstName = value; }
        public string LastName { get => _lastName; private set => _lastName = value; }
        public string CommentText { get => _commentText; private set => _commentText = value; }
        public string EmailSufix { get => _emailSufix; private set => _emailSufix = value; }
        public string EmailNumber { get => _emailNumber; private set => _emailNumber = value; }


        public void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
