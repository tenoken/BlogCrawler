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

        public SpreadSheetReportService() : base()
        {
        }

        public void CreateReport(List<Article> articlesList, string path)
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
                    string file = Path.Combine(path, $"Report_{date}.xlsx");
                    File.WriteAllBytes(file, excelPackage.GetAsByteArray());
                }

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
