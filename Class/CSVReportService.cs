using BlogCrawler.Class.Abstracts;
using BlogCrawler.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Class
{
    public sealed class CSVReportService : Report, ICSVReportService, IDisposable
    {
        private readonly List<Article> _articlesList;
        private readonly string _path = @"D:\Projects\WebScraping\WebScrapingDemo\WebScrapingDemo\Relatorios\";

        public List<Article> ArticlesList => _articlesList;

        public CSVReportService(List<Article> articlesList) : base(articlesList)
        {
            _articlesList = articlesList;
        }

        public bool CreateReport(List<Article> articlesList)
        {
            try
            {
                // Set Path
                Directory.CreateDirectory(_path);
                // Format file name with valid chars
                string date = DateTime.Now.Date.ToString().Replace('/', '-').Replace(':', '-');
                string file = Path.Combine(_path, $"Report_{date}.csv");
                File.Create(file).Dispose();

                var line = new StringBuilder();
                List<string> linesList = new List<string>();

                foreach (var article in _articlesList)
                {
                    line.Append($"{article.Title},{article.Overview},{article.Link}\n");
                }

                File.WriteAllLines(file, linesList);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
