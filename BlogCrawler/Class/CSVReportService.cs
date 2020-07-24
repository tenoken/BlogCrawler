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

        public CSVReportService() : base()
        {
        }

        public void CreateReport(List<Article> articlesList, string path)
        {
            try
            {

                string date = DateTime.Now.Date.ToString("dd/MM/yyyy").Replace('/', '-');
                string file = Path.Combine(path, $"Report_{date}.csv");
                File.Create(file).Dispose();

                var line = new StringBuilder();
                List<string> linesList = new List<string>();

                foreach (var article in articlesList)
                {
                    line.Append($"\n{article.Title},\n{article.Link}");
                }

                linesList.Add(line.ToString());

                File.WriteAllLines(file, linesList, new UTF8Encoding(true));
              
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (DirectoryNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
