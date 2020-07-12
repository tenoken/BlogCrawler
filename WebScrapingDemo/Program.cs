using BlogCrawler.Class;
using BlogCrawler.Driver;
using BlogCrawler.Interfaces;
using SimpleInjector.Lifestyles;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WebScrapingDemo
{
    static class Program
    {
        public static Container container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            //Application.Run(new Form1());
            //Application.Run(container.GetInstance<Form1>());
            Application.Run(container.GetInstance<Client>());
        }

        private static void Bootstrap()
        {
            // Create the container as usual.
            container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Options.EnableAutoVerification = false;

            container.Register<ICommentService, CommentService>();
            container.Register<ISpreadSheetReportService, SpreadSheetReportService>();
            container.Register<ITextReportService, TextReportService>();
            container.Register<ICSVReportService, CSVReportService>();
            container.Register<IArticleService, ArticleService>();
            container.Register<Client>();
            container.Collection.Register(new Article("", "", ""));
            container.Register(() => new MainForm(
                                new CommentService(new Comment("", "", "", "", "")),
                                new SpreadSheetReportService(new List<Article>()),
                                new TextReportService(new List<Article>()),
                                new CSVReportService(new List<Article>()),
                                new ArticleService(new Article("", "", ""))
                ));

            // Optionally verify the container.
            //container.Verify();
        }
    }
}
