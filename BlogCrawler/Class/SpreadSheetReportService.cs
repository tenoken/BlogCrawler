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
    public sealed class SpreadSheetReportService : Report, ISpreadSheetReportService
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

                    foreach (var article in articlesList)
                    {
                        sheet.Cells[linePosition, 1].Value = article.Title;
                        sheet.Cells[linePosition, 2].Value = article.Overview;
                        sheet.Cells[linePosition, 3].Value = article.Link;

                        linePosition++;
                    }

                    string date = DateTime.Now.Date.ToString("dd/MM/yyyy").Replace('/', '-'); 
                    string file = Path.Combine(_path, $"Report_{date}.xlsx");
                    File.WriteAllBytes(file, excelPackage.GetAsByteArray());
                }

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
