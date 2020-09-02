using BlogCrawler.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlogCrawler.Interfaces
{
    public interface ICommentService
    {
        List<Comment> CreateRandomComments();

        void PostComment(List<string> articleList, List<Article> articlesList, string url, CancellationToken token);
    }
}
