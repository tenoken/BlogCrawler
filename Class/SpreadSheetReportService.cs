using BlogCrawler.Class.Abstracts;
using BlogCrawler.Interfaces;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCrawler.Class
{
    public sealed class SpreadSheetReportService : Report, ISpreadSheetReportService, IDisposable
    {
        private readonly List<Article> _articlesList;
        private readonly string _path = @"D:\Projects\WebScraping\WebScrapingDemo\WebScrapingDemo\Relatorios\";

        public List<Article> ArticlesList => _articlesList;

        public SpreadSheetReportService(List<Article> articlesList) : base(articlesList)
        {
            _articlesList = articlesList;
        }

        public bool CreateReport(List<Article> articlesList)
        {
            try
            {
                using (var excelPackage = new ExcelPackage())
                {
                    // Add extra properties into file
                    excelPackage.Workbook.Properties.Author = "John Smith";
                    excelPackage.Workbook.Properties.Title = "Meu Excel";

                    // Initialize the spreadsheet
                    var sheet = excelPackage.Workbook.Worksheets.Add("Planilha 1");
                    sheet.Name = "Planilha 1";

                    // Header
                    var index = 1;
                    var sheetHeader = new String[] { "Titulo", "Previa", "Link" };
                    foreach (var titulo in sheetHeader)
                    {
                        sheet.Cells[1, index++].Value = titulo;
                    }

                    // Line index of the spreadsheet 
                    int linePosition = 2;

                    foreach (var article in _articlesList)
                    {
                        sheet.Cells[linePosition, 1].Value = article.Title;
                        sheet.Cells[linePosition, 2].Value = article.Overview;
                        sheet.Cells[linePosition, 3].Value = article.Link;

                        linePosition++;
                    }

                    //Format file name with valid chars
                    string date = DateTime.Now.Date.ToString().Replace('/', '-').Replace(':', '-');
                    string file = Path.Combine(_path, $"Report_{date}.xlsx");
                    File.WriteAllBytes(file, excelPackage.GetAsByteArray());
                }

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
