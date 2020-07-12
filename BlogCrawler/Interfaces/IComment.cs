using BlogCrawler.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Interfaces
{
    public interface IComment
    {
        string GetComment(Comment comment);

        string FormatEmail(Comment comment);

        string FormatAuthor(Comment comment);

        Comment CreateComment(string firstName, string lastName, string emailNumber, string emailSufix, string commentText);
    }
}
