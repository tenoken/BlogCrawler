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
    public sealed class TextReportService : Report, ITextReportService, IDisposable
    {
        private readonly List<Article> _articlesList;
        private readonly string _path = @"D:\Projects\WebScraping\WebScrapingDemo\WebScrapingDemo\Relatorios\";

        public List<Article> ArticleList => _articlesList;

        public TextReportService(List<Article> articlesList) : base(articlesList)
        {
            _articlesList = articlesList;
        }

        public bool CreateReport(List<Article> articlesList)
        {
            try
            {
                // Set Path
                Directory.CreateDirectory(_path);
                string date = DateTime.Now.Date.ToString().Replace('/', '-').Replace(':', '-'); //Format file name with valid chars
                string file = Path.Combine(_path, $"Report_{date}.txt");
                File.Create(file).Dispose();

                var line = string.Empty;
                List<string> linesList = new List<string>();

                foreach (var article in _articlesList)
                {
                    line += $"Título: {article.Title} \n";
                    line += $"Prévia: {article.Overview} \n";
                    line += $"Link: {article.Link} \n";
                    line += "\n";

                    linesList.Add(line);
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
