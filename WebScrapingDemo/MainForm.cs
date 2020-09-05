using BlogCrawler.Class;
using BlogCrawler.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        delegate void InsertRowGridFuncionality(string title, string overview, string link, Bitmap image);

        private CancellationTokenSource _source;

        public MainForm(ICommentService commentService,
                        ISpreadSheetReportService spreadSheetReportService, ITextReportService textReportService,
                        ICSVReportService cSVReportService, IArticleService articleService, CancellationTokenSource source)
        {
            _commentService = commentService;
            _spreadSheetReportService = spreadSheetReportService;
            _textReportService = textReportService;
            _cSVReportService = cSVReportService;
            _articleService = articleService;
            _source = source;

            InitializeComponent();
        }

        #region Events

        private async void buttonUpdate_Click(object sender, EventArgs e)
        {

            _source = new CancellationTokenSource();
            var blogPosts = new Task(() => { });

            EnableAnimations();
            ClearGridRows();

            try
            {
                blogPosts = Task.Run(() =>
                {
                    var articles = _articleService.GetArticleContent();
                    var title = _articleService.GetPageTitle();

                    if (_source.IsCancellationRequested)
                        _source.Token.ThrowIfCancellationRequested();

                    UpdateBlogPosts(articles, title, _source.Token);
                }, _source.Token);

                await blogPosts;
            }
            catch (OperationCanceledException ex)
            {
                _logger.Warn(ex, ex.Message);
                MessageBox.Show("Process was aborted!", "Process Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                MessageBox.Show("An unexpected error occurred", "Process Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DisableAnimations();
                _source.Dispose();

                VerifyReportButton(blogPosts);
            }
        }     

        private async void buttonPostComments_Click(object sender, EventArgs e)
        {
            _source = new CancellationTokenSource();
            var blogPosts = new Task(() => { });

            EnableAnimations();

            try
            {
                blogPosts = Task.Run(() =>
                {
                    var title = _articleService.GetPageTitle();
                    var articles = _articleService.GetArticleContent();
                    var url = _articleService.GetCurrentUrl();
                    var ids = _articleService.GetArticlesId();

                    if (_source.IsCancellationRequested)
                        _source.Token.ThrowIfCancellationRequested();

                    var comments = _commentService.CreateRandomComments();

                    for (int i = 0; i < articles.Count(); i++)
                    {
                        _articleService.AddComment(articles[i], comments[i]);
                    }

                    _commentService.PostComment(ids, articles, url, _source.Token);
                }, _source.Token);

                await blogPosts;

            }
            catch (OperationCanceledException ex)
            {
                _logger.Warn(ex, ex.Message);
                MessageBox.Show("Process was aborted!", "Process Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                MessageBox.Show("An unexpected error occurred", "Process Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DisableAnimations();
                _source.Dispose();

                VerifyReportButton(blogPosts);
            }
        }

        private async void buttonTextReport_Click(object sender, EventArgs e)
        {
            _source = new CancellationTokenSource();
            var blogPosts = new Task(() => { });

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {

                    blogPosts = Task.Run(() =>
                    {
                        string[] files = Directory.GetFiles(fbd.SelectedPath);

                        var articles = _articleService.GetArticleContent();

                        try
                        {
                            _textReportService.CreateReport(articles, fbd.SelectedPath);

                            MessageBox.Show("Saved successufuly!", "Process Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(ex, ex.Message);
                            MessageBox.Show("An error occurred while creating the report.", "Process Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }, _source.Token);

                    await blogPosts;
                }

            }
        }

        private async void buttonSheetReport_Click(object sender, EventArgs e)
        {
            var blogPosts = new Task(() => { });

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {

                    blogPosts = Task.Run(() =>
                    {
                        string[] files = Directory.GetFiles(fbd.SelectedPath);

                        var articles = _articleService.GetArticleContent();

                        try
                        {
                            _spreadSheetReportService.CreateReport(articles, fbd.SelectedPath);

                            MessageBox.Show("Saved successufuly!", "Process Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(ex, ex.Message);
                            MessageBox.Show("An error occurred while creating the report.", "Process Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }, _source.Token);

                    await blogPosts;
                }
            }
        }

        private async void buttonGetPrevious_Click(object sender, EventArgs e)
        {
            var blogPosts = new Task(() => { });
            var currentPage = "";
            var wasCanceled = false;
            _source = new CancellationTokenSource();

            EnableAnimations();
            ClearGridRows();

            try
            {
                blogPosts = Task.Run(() =>
                {
                    var articles = _articleService.GetPreviousPage();
                    var title = _articleService.GetPageTitle();
                    currentPage = title;

                    if (_source.IsCancellationRequested)
                        _source.Token.ThrowIfCancellationRequested();

                    UpdateBlogPosts(articles, title, _source.Token);
                }, _source.Token);

                await blogPosts;

            }
            catch (OperationCanceledException ex)
            {
                wasCanceled = true;
                _logger.Warn(ex, ex.Message);
                MessageBox.Show("Process was aborted!", "Process Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                wasCanceled = true;
                _logger.Error(ex, ex.Message);
                MessageBox.Show("An unexpected error occurred", "Process Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                DisableAnimations();
                _source.Dispose();

                if (currentPage.Equals("Japão em Foco - Curiosidades e Cultura Japonesa"))
                    DisablePreviousButton();

                VerifyReportButton(blogPosts);

                if (wasCanceled)
                    VerifyReportButton(blogPosts, true);
                else
                    VerifyReportButton(blogPosts);
            }
        }

        private async void buttonNextPage_Click(object sender, EventArgs e)
        {
            _source = new CancellationTokenSource();
            var blogPosts = new Task(() => { });
            var wasCanceled = false;

            EnableAnimations();
            ClearGridRows();

            try
            {
                blogPosts = Task.Run(() =>
                {
                    var articles = _articleService.GetNextPage();
                    var title = _articleService.GetPageTitle();

                    UpdateBlogPosts(articles, title, _source.Token);
                }, _source.Token);

                await blogPosts;
            }
            catch (OperationCanceledException ex)
            {
                wasCanceled = true;
                _logger.Warn(ex, ex.Message);
                MessageBox.Show("Process was aborted!", "Process Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                wasCanceled = true;
                _logger.Error(ex, ex.Message);
                MessageBox.Show("An unexpected error occurred", "Process Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                DisablePreviousButton();
                DisableAnimations();
                _source.Dispose();

                if(wasCanceled)
                    VerifyReportButton(blogPosts);
                else                    
                    VerifyReportButton(blogPosts, true);
            }
        }

        private async void buttonCSVReport_Click(object sender, EventArgs e)
        {
            _source = new CancellationTokenSource();
            var blogPosts = new Task(() => { });

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {

                    blogPosts = Task.Run(() =>
                    {
                        string[] files = Directory.GetFiles(fbd.SelectedPath);

                        var articles = _articleService.GetArticleContent();

                        try
                        {
                            _cSVReportService.CreateReport(articles, fbd.SelectedPath);

                            MessageBox.Show("Saved successufuly!", "Process Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(ex, ex.Message);
                            MessageBox.Show("An error occurred while creating the report.", "Process Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }, _source.Token);

                    await blogPosts;

                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                Process.Start(new ProcessStartInfo(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            processStatusLabel.Text = "O processo está sendo abortado...";
            _source.Cancel();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var aboutForm = new About();
            aboutForm.Show();
        }

        #endregion

        #region Methods

        // TODO: Extract the bellow methods to a partial class
        private void DisableAnimations()
        {
            DisableGeishaGif();
            HideProcessStatusLabel();
            DisableSharinGif();
            DisableStopLabel();
            DisableStopButton();
        }

        private void EnableAnimations()
        {
            EnableGeishaGif();
            ShowProcessStatusLabel();
            EnableSharinGif();
            EnableStopButton();
            EnableStopLabel();
        }

        private void VerifyReportButton(Task blogPosts, bool enablePreviosButton = false)
        {
            if (!blogPosts.IsCanceled)
            {
                EnableReportButtons();
                EnablePostCommentButton();
            }
            else
            {
                DisableReportButtons();
                DisablePostCommentButton();
            }

            if (enablePreviosButton)
                EnablePreviousButton();
        }

        private void UpdateBlogPosts(List<Article> articles, string title, CancellationToken token)
        {

            foreach (var article in articles)
            {
                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
                  
                //Create a delagate for the above method
                using (article)
                {

                    if (dataGridView1.InvokeRequired)
                    {
                        InsertRowGridFuncionality d = new InsertRowGridFuncionality(InsertRowGrid);
                        this.Invoke(d, new object[] { article.Title, article.Overview, article.Link, article.Image });
                    }
                    else
                        InsertRowGrid(article.Title, article.Overview, article.Link, article.Image);

                }
            }
        }

        private void InsertRowGrid(string title, string overview, string link, Bitmap image)
        {
            dataGridView1.Rows.Add(title, overview, link, image);
        }

        private void ClearGridRows()
        {
            dataGridView1.Rows.Clear();
        }
      
        private void EnableReportButtons()
        {
            buttonCSVReport.Enabled = true;
            buttonTextReport.Enabled = true;
            buttonSheetReport.Enabled = true;
        }

        private void DisableReportButtons()
        {
            buttonCSVReport.Enabled = false;
            buttonTextReport.Enabled = false;
            buttonSheetReport.Enabled = false;
        }

        private void EnablePreviousButton()
        {
            buttonGetPrevious.Enabled = true;
        }

        private void DisablePreviousButton()
        {
            buttonGetPrevious.Enabled = false;
        }

        private void EnableGrid()
        {
            dataGridView1.Visible = true;
        }

        private void DisabelGrid()
        {
            dataGridView1.Visible = false;
        }

        private void EnableGeishaGif()
        {
            geishaGif.Visible = true;
        }

        private void DisableGeishaGif()
        {
            geishaGif.Visible = false;
        }

        private void ShowProcessStatusLabel()
        {
            processStatusLabel.Visible = true;
            processStatusLabel.Text = "Procurando novos posts, aguarde por favor...";
        }

        private void HideProcessStatusLabel()
        {
            processStatusLabel.Visible = false;
            processStatusLabel.Text = "";
        }

        private void EnableSharinGif()
        {
            sharinGif.Visible = true;
        }

        private void DisableSharinGif()
        {
            sharinGif.Visible = false;
        }

        private void EnablePostCommentButton()
        {
            buttonPostComments.Enabled = true;
        }

        private void DisablePostCommentButton()
        {
            buttonPostComments.Enabled = false;
        }

        private void EnableStopButton()
        {
            stopButton.Visible = true;
        }

        private void DisableStopButton()
        {
            stopButton.Visible = false;         
        }

        private void EnableStopLabel()
        {
            stopLabel.Visible = true;
        }

        private void DisableStopLabel()
        {
            stopLabel.Visible = false;
        }

        #endregion
    }
}

