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
    public sealed class TextReportService : Report, ITextReportService
    {

        public TextReportService() : base()
        {
        }

        public void CreateReport(List<Article> articlesList, string path)
        {
            try
            {

                string date = DateTime.Now.Date.ToString("dd/MM/yyyy").Replace('/', '-'); 
                string file = Path.Combine(path, $"Report_{date}.txt");
                File.Create(file).Dispose();

                var line = string.Empty;
                List<string> linesList = new List<string>();

                foreach (var article in articlesList)
                {
                    line += $"Título: {article.Title} \n";
                    line += $"Prévia: {article.Overview} \n";
                    line += $"Link: {article.Link} \n";
                    line += "\n";

                }

                linesList.Add(line);

                File.WriteAllLines(file, linesList);

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
