//using BlogCrawler.Interfaces;
//using System;
//using System.Collections.Generic;
//using SimpleInjector;
//using System.Windows.Forms;
//using BlogCrawler.Driver;
//using BlogCrawler.Class;
//using SimpleInjector.Lifestyles;
//using log4net.Config;

//namespace BlogCrawler
//{
//    static class Program
//    {
//        private static Container container;
//        /// <summary>
//        /// The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {
//            Application.EnableVisualStyles();
//            Application.SetCompatibleTextRenderingDefault(false);
//            Bootstrap();
//            //XmlConfigurator.Configure();
//            //Application.Run(new Client());
//            //Application.Run(new TestForm());
//            Application.Run(container.GetInstance<TestForm>());
//        }

//        private static void Bootstrap()
//        {
//            // Create the container as usual.
//            container = new Container();

//            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
//            container.Options.EnableAutoVerification = false;

//            container.Register<ICommentService, CommentService>();
//            container.Register<ISpreadSheetReportService, SpreadSheetReportService>();
//            container.Register<ITextReportService, TextReportService>();
//            container.Register<ICSVReportService, CSVReportService>();
//            container.Register<IArticleService, ArticleService>();
//            container.Collection.Register(new Article("","",""));
//            container.Register(() => new TestForm(
//                                new CommentService(new Comment("", "", "", "", "")),
//                                new SpreadSheetReportService(),
//                                new TextReportService(),
//                                new CSVReportService(),
//                                new ArticleService(new Article("","",""))
//                ));

//            // Optionally verify the container.
//            //container.Verify();
//        }
//    }
//}
