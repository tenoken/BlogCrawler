using BlogCrawler.Class;
using BlogCrawler.Crawler;
using BlogCrawler.Driver;
using BlogCrawler.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlogCrawler
{
    public partial class TestForm : Form
    {
        private readonly IHomePageService _homePageService;

        private readonly ICommentService _commentService;

        private readonly ISpreadSheetReportService _spreadSheetReportService;

        private readonly ITextReportService _textReportService;

        private readonly ICSVReportService _cSVReportService;

        private readonly IArticleService _articleService;

        //public TestForm()
        //{
        //    InitializeComponent();
        //}

        public TestForm(IHomePageService homePageService, ICommentService commentService, 
                        ISpreadSheetReportService spreadSheetReportService, ITextReportService textReportService, 
                        ICSVReportService cSVReportService, IArticleService articleService)
        {
            _homePageService = homePageService;
            _commentService = commentService;
            _spreadSheetReportService = spreadSheetReportService;
            _textReportService = textReportService;
            _cSVReportService = cSVReportService;
            _articleService = articleService;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var articles = _articleService.GetArticleContent();
            var title = _articleService.GetPageTitle();

            //var homepage = _homePageService.CreateHomePage(title, articles);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var articles = _articleService.GetNextPage();
            var title = _articleService.GetPageTitle();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var articles = _articleService.GetPreviousPage();
            var title = _articleService.GetPageTitle();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            var title = _articleService.GetPageTitle();
            var articles = _articleService.GetArticleContent();
            var url = _articleService.GetCurrentUrl();
            var ids = _articleService.GetArticlesId();

            var comments = _commentService.CreateRandomComments();

            for (int i = 0; i < articles.Count(); i++)
            {
                _articleService.AddComment(articles[i], comments[i]);
            }

            _commentService.PostComment(ids, articles, url);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            var articles = _articleService.GetArticleContent();

            if(_textReportService.CreateReport(articles))
                MessageBox.Show("Salvo com sucesso!");
            else
                MessageBox.Show("Houve um erro ao gerar o relatorio");
        }

        private void button6_Click(object sender, EventArgs e)
        {

            var articles = _articleService.GetArticleContent();

            if (_cSVReportService.CreateReport(articles))
                MessageBox.Show("Salvo com sucesso!");
            else
                MessageBox.Show("Houve um erro ao gerar o relatorio");
        }

        private void button7_Click(object sender, EventArgs e)
        {

            var articles = _articleService.GetArticleContent();

            if (_spreadSheetReportService.CreateReport(articles))
                MessageBox.Show("Salvo com sucesso!");
            else
                MessageBox.Show("Houve um erro ao gerar o relatorio");
        }
    }
}
