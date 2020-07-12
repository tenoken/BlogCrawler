using BlogCrawler.Interfaces;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WebScrapingDemo
{
    public partial class MainForm : Form
    {

        private readonly ICommentService _commentService;

        private readonly ISpreadSheetReportService _spreadSheetReportService;

        private readonly ITextReportService _textReportService;

        private readonly ICSVReportService _cSVReportService;

        private readonly IArticleService _articleService;

        public MainForm(ICommentService commentService,
                        ISpreadSheetReportService spreadSheetReportService, ITextReportService textReportService,
                        ICSVReportService cSVReportService, IArticleService articleService)
        {
            _commentService = commentService;
            _spreadSheetReportService = spreadSheetReportService;
            _textReportService = textReportService;
            _cSVReportService = cSVReportService;
            _articleService = articleService;

            InitializeComponent();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            var articles = _articleService.GetArticleContent();
            var title = _articleService.GetPageTitle();

            foreach (var article in articles)
            {
                InsertRowGrid(article.Title, article.Overview, article.Link, article.Image);
            }
        }

        private void buttonPostComments_Click(object sender, EventArgs e)
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

        private void buttonTextReport_Click(object sender, EventArgs e)
        {
            var articles = _articleService.GetArticleContent();

            if (_textReportService.CreateReport(articles))
                MessageBox.Show("Saved successufuly!");
            else
                MessageBox.Show("An error occurred while creating the report.");
        }

        private void buttonSheetReport_Click(object sender, EventArgs e)
        {
            var articles = _articleService.GetArticleContent();

            if (_spreadSheetReportService.CreateReport(articles))
                MessageBox.Show("Saved successufuly!");
            else
                MessageBox.Show("An error occurred while creating the report.");
        }

        private void buttonGetPrevious_Click(object sender, EventArgs e)
        {
            var articles = _articleService.GetPreviousPage();
            var title = _articleService.GetPageTitle();
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            var articles = _articleService.GetNextPage();
            var title = _articleService.GetPageTitle();
        }

        private void buttonCSVReport_Click(object sender, EventArgs e)
        {
            var articles = _articleService.GetArticleContent();

            if (_cSVReportService.CreateReport(articles))
                MessageBox.Show("Saved successufuly!");
            else
                MessageBox.Show("An error occurred while creating the report.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                Process.Start(new ProcessStartInfo(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
            }
        }

        private void InsertRowGrid(string title, string overview, string link, Bitmap image)
        {
            dataGridView1.Rows.Add(title, overview, link, image);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

