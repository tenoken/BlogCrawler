using BlogCrawler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Class
{
    public class Comment : IComment, IDisposable
    {
        private string _firstName;
        private string _lastName;
        private string _commentText;
        private string _emailSufix;
        private string _emailNumber;

        private bool _disposed = false;

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

        public Comment CreateComment(string firstName, string lastName, string emailNumber, string emailSufix, string commentText)
        {
            return new Comment(firstName, lastName, emailNumber, emailSufix, commentText);
        }

        public string FormatAuthor(Comment comment)
        {
            var firstLetterLastName = comment.LastName.ToString().Substring(0)[0];
            var lastNameWithOutFirstLetter = comment.LastName.ToString().Substring(1).ToLower();
            //return string.Format("{0} {1}", comment.FirstName, comment.LastName.ToString().Substring(0)[0] + lastNameToLower);
            return string.Format($"{comment.FirstName} {firstLetterLastName + lastNameWithOutFirstLetter}");
        }

        public string FormatEmail(Comment comment)
        {
            var firstNameFormated = comment.FirstName.ToLower();
            var lastNameFormated = comment.LastName.ToLower();

            return string.Format($"{firstNameFormated}{lastNameFormated}{comment.EmailNumber}@{comment.EmailSufix}");
        }

        public string GetComment(Comment comment)
        {
            return comment.CommentText;
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
                    this.Dispose();
                }

                _disposed = true;

            }
        }
    }
}
