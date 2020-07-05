using BlogCrawler.Class;
using BlogCrawler.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Driver
{
    class ArticleService : IArticleService
    {
        private const string titleXpath = "/html[1]/head[1]/title[1]";

        private const string articleListXpath = "//article[contains(@class,'artigo')]";

        private const string articleContentXpath = "/html[1]/body[1]/div[2]/div[1]/section[1]/div[1]/article[1]";

        private int _pageIndex;//= 1;
        private string _url;// = "https://japaoemfoco.com";
        private IArticle _article;

        public ArticleService(IArticle article)
        {                  
            _article = article;
            _pageIndex = 1;
            _url = "https://japaoemfoco.com";
    }

        /// <summary>
        /// Get page title
        /// </summary>
        /// <returns>the title from the browser tab</returns>
        public string GetPageTitle()
        {
            var htmlContent = GetPageContent(ConcatURL());
            return htmlContent.DocumentNode.SelectSingleNode(titleXpath).InnerHtml;
        }

        /// <summary>
        /// Concats the base URI with the current URL
        /// </summary>
        /// <returns></returns>
        private string ConcatURL()
        {
            return _url + @"/page/" + _pageIndex.ToString();
        }

        /// <summary>
        /// Get current URL
        /// </summary>
        /// <returns>Current URL of the crawled articles</returns>
        public string GetCurrentUrl()
        {
            var currentUrl = string.Empty;
            return currentUrl = _url + @"/page/" + _pageIndex.ToString();
        }

        /// <summary>
        /// Get articles's post id
        /// </summary>
        /// <returns></returns>
        public List<string> GetArticlesId()
        {
            List<string> articlesIdList = new List<string>();
            HtmlDocument pageContent = GetPageContent(ConcatURL());

            HtmlNodeCollection articlesList = pageContent.DocumentNode.SelectNodes(articleListXpath);
            articlesList.ToList().ForEach(x => articlesIdList.Add(x.Id));

            return articlesIdList;
        }

        /// <summary>
        /// Get article's content 
        /// </summary>
        /// <returns>An article list from the current URL</returns>
        public List<Article> GetArticleContent()
        {
            HtmlNodeCollection articlesCollection = GetArticles(ConcatURL());
            return CreateArticles(articlesCollection);
        }

        /// <summary>
        /// Get articles from the next page 
        /// </summary>
        /// <returns>An artile list</returns>
        public List<Article> GetNextPage()
        {
            _pageIndex++;
            HtmlNodeCollection articlesCollection = GetArticles(ConcatURL());
            return CreateArticles(articlesCollection);
        }

        /// <summary>
        /// Get articles from the previous page
        /// </summary>
        /// <returns>An article list</returns>
        public List<Article> GetPreviousPage()
        {
            if (!_pageIndex.Equals(1))
                _pageIndex--;

            HtmlNodeCollection articlesCollection = GetArticles(ConcatURL());
            return CreateArticles(articlesCollection);
        }

        /// <summary>
        /// Add a comment to an article
        /// </summary>
        /// <param name="article">Article that will recieve the comment</param>
        /// <param name="comment">Comment to be added</param>
        public void AddComment(Article article, Comment comment)
        {
            article.CommentsList.Add(comment);
        }

        /// <summary>
        /// Get articles from the specifc URL
        /// </summary>
        /// <param name="url">URL to be crawled</param>
        /// <returns>Collection of node(from DOM object)</returns>
        private HtmlNodeCollection GetArticles(string url)
        {
            HtmlDocument pageContent = GetPageContent(url);

            return pageContent.DocumentNode.SelectNodes(articleListXpath);
        }

        /// <summary>
        /// Get current page's content
        /// </summary>
        /// <param name="url">URL to be crawled</param>
        /// <returns>page's html document</returns>
        private HtmlDocument GetPageContent(string url)
        {

            var webClient = new WebClient();
            string page = string.Empty;
            HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();

            webClient.Encoding = Encoding.UTF8;
            page = webClient.DownloadString(url);
            htmlDocument.LoadHtml(page);

            return htmlDocument;
        }

        /// <summary>
        /// Create a list of articles
        /// </summary>
        /// <param name="articlesCollection">Collection to be crawled</param>
        /// <returns>An article list</returns>
        private List<Article> CreateArticles(HtmlNodeCollection articlesCollection)
        {
            string title = "";
            string overview = "";
            string link = "";
            string imagePath = "";

            List<Article> articlesList = _article.CreateArticleList();

            foreach (var article in articlesCollection)
            {
                var getTagName = article.SelectSingleNode(articleContentXpath);

                if (article.Name.Equals("article"))
                {
                    var element = article.ChildNodes[3].ChildNodes;

                    title = WebUtility.HtmlDecode(element[1].InnerText.Replace("\n", ""));
                    overview = WebUtility.HtmlDecode(element[2].InnerText.Replace("\n", "").TrimStart().TrimEnd());
                    link = WebUtility.HtmlDecode(element[1].ChildNodes[0].Attributes["href"].Value);
                    imagePath = article.ChildNodes[1].ChildNodes[1].ChildNodes[1].ChildNodes[1].Attributes["src"].Value;

                    var bitmapImage = GetArticleImage(imagePath);

                    Article newArticle = _article.CreateArticle(title, overview, link, bitmapImage);

                    articlesList.Add(newArticle);
                }
            }

            return articlesList;
        }

        /// <summary>
        /// Get the article image 
        /// </summary>
        /// <param name="imagePath">Path of the article image</param>
        /// <returns>bitmap image</returns>
        private Bitmap GetArticleImage(string imagePath)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(imagePath.ToString());
            myRequest.Method = "GET";
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
            myResponse.Close();

            return bmp;
        }
    }
}
