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
    public sealed class CSVReportService : Report, ICSVReportService
    {
        private readonly List<Article> _articlesList;
        private readonly string _path = @"D:\Projects\WebScraping\WebScrapingDemo\WebScrapingDemo\Relatorios\";

        // TODO: Remove load from constructor, once the private list became useless 
        public List<Article> ArticlesList => _articlesList;

        public CSVReportService(List<Article> articlesList) : base(articlesList)
        {
            _articlesList = articlesList;
        }

        public bool CreateReport(List<Article> articlesList)
        {
            try
            {

                Directory.CreateDirectory(_path);

                string date = DateTime.Now.Date.ToString("dd/MM/yyyy").Replace('/', '-');
                string file = Path.Combine(_path, $"Report_{date}.csv");
                File.Create(file).Dispose();

                var line = new StringBuilder();
                List<string> linesList = new List<string>();

                foreach (var article in articlesList)
                {
                    line.Append($"{article.Title},{article.Overview},{article.Link}\n");
                }

                linesList.Add(line.ToString());

                File.WriteAllLines(file, linesList, new UTF8Encoding(true));

                return true;
            }
            catch (ArgumentNullException ex)
            {
                var customMessage = "The path argument is null.";
                Console.WriteLine(WriteExceptionMessage(customMessage, ex));
                return false;
            }
            catch (ArgumentException ex)
            {
                var customMessage = "There is an error within path argument.";
                Console.WriteLine(WriteExceptionMessage(customMessage, ex));
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                var customMessage = "The access to this path was unauthorized.";
                Console.WriteLine(WriteExceptionMessage(customMessage, ex));
                return false;
            }
            catch (PathTooLongException ex)
            {
                var customMessage = "The reffered path is too long.";
                Console.WriteLine(WriteExceptionMessage(customMessage, ex));
                return false;
            }
            catch (DirectoryNotFoundException ex)
            {
                var customMessage = "The reffered directory was not found.";
                Console.WriteLine(WriteExceptionMessage(customMessage, ex));
                return false;
            }
            catch (IOException ex)
            {
                var customMessage = "An error occurred while creating the file.";
                Console.WriteLine(WriteExceptionMessage(customMessage, ex));
                return false;
            }
            catch (NotSupportedException ex)
            {
                var customMessage = "Not supported output.";
                Console.WriteLine(WriteExceptionMessage(customMessage, ex));

                return false;
            }
            catch (Exception ex)
            {
                var customMessage = "An error occurred";
                Console.WriteLine(WriteExceptionMessage(customMessage, ex));
                return false;
            }
        }

        private string WriteExceptionMessage(string customExceptionMessage, Exception ex)
        {
            return string.Format($"TextReportService: {customExceptionMessage} \n " +
                $"Message: {ex.Message} \n " +
                $"Source: {ex.Source} \n " +
                $"StackTrace: {ex.StackTrace} \n " +
                $"TargetSite: {ex.TargetSite}");
        }
    }
}
