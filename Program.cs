using BlogCrawler.Interfaces;
using System;
using System.Collections.Generic;
using SimpleInjector;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlogCrawler.Driver;
using BlogCrawler.Class;
using BlogCrawler.Crawler;
using SimpleInjector.Lifestyles;

namespace BlogCrawler
{
    static class Program
    {
        private static Container container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Bootstrap();
            //Application.Run(new Client());
            //Application.Run(new TestForm());
            Application.Run(container.GetInstance<TestForm>());
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
            container.Register<IHomePageService, HomePageService>();
            container.Collection.Register(new Article("","",""));
            container.Register(() => new HomePage("", new List<Article>()));
            container.Register(() => new TestForm(new HomePageService(new ArticleService()),
                                new CommentService(),
                                new SpreadSheetReportService(new List<Article>()),
                                new TextReportService(new List<Article>()),
                                new CSVReportService(new List<Article>()),
                                new ArticleService()
                ));

            // Optionally verify the container.
            //container.Verify();
        }
    }
}
