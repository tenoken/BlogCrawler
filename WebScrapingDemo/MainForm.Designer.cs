namespace WebScrapingDemo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Link = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Imagem = new System.Windows.Forms.DataGridViewImageColumn();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonTextReport = new System.Windows.Forms.Button();
            this.buttonSheetReport = new System.Windows.Forms.Button();
            this.buttonGetPrevious = new System.Windows.Forms.Button();
            this.buttonNextPage = new System.Windows.Forms.Button();
            this.buttonPostComments = new System.Windows.Forms.Button();
            this.japaoEmFoco = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCSVReport = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.processStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Titulo,
            this.Subtitulo,
            this.Link,
            this.Imagem});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(29, 65);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(926, 345);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Titulo
            // 
            this.Titulo.HeaderText = "Titulo";
            this.Titulo.Name = "Titulo";
            this.Titulo.Width = 435;
            // 
            // Subtitulo
            // 
            this.Subtitulo.HeaderText = "Previa";
            this.Subtitulo.Name = "Subtitulo";
            this.Subtitulo.Width = 435;
            // 
            // Link
            // 
            this.Link.HeaderText = "Link";
            this.Link.Name = "Link";
            this.Link.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Link.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Link.Width = 538;
            // 
            // Imagem
            // 
            this.Imagem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Imagem.HeaderText = "Imagem";
            this.Imagem.Name = "Imagem";
            this.Imagem.Width = 5;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(18)))), ((int)(((byte)(33)))));
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonUpdate.Location = new System.Drawing.Point(29, 443);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(136, 27);
            this.buttonUpdate.TabIndex = 1;
            this.buttonUpdate.Text = "Atualizar Notícias";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonTextReport
            // 
            this.buttonTextReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTextReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(18)))), ((int)(((byte)(33)))));
            this.buttonTextReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTextReport.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonTextReport.ForeColor = System.Drawing.Color.White;
            this.buttonTextReport.Location = new System.Drawing.Point(29, 482);
            this.buttonTextReport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonTextReport.Name = "buttonTextReport";
            this.buttonTextReport.Size = new System.Drawing.Size(136, 28);
            this.buttonTextReport.TabIndex = 2;
            this.buttonTextReport.Text = "Relatório .txt";
            this.buttonTextReport.UseVisualStyleBackColor = false;
            this.buttonTextReport.Click += new System.EventHandler(this.buttonTextReport_Click);
            // 
            // buttonSheetReport
            // 
            this.buttonSheetReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSheetReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(18)))), ((int)(((byte)(33)))));
            this.buttonSheetReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSheetReport.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonSheetReport.ForeColor = System.Drawing.Color.White;
            this.buttonSheetReport.Location = new System.Drawing.Point(169, 482);
            this.buttonSheetReport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSheetReport.Name = "buttonSheetReport";
            this.buttonSheetReport.Size = new System.Drawing.Size(140, 28);
            this.buttonSheetReport.TabIndex = 3;
            this.buttonSheetReport.Text = "Relatório .xls";
            this.buttonSheetReport.UseVisualStyleBackColor = false;
            this.buttonSheetReport.Click += new System.EventHandler(this.buttonSheetReport_Click);
            // 
            // buttonGetPrevious
            // 
            this.buttonGetPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(18)))), ((int)(((byte)(33)))));
            this.buttonGetPrevious.Enabled = false;
            this.buttonGetPrevious.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(18)))), ((int)(((byte)(33)))));
            this.buttonGetPrevious.FlatAppearance.BorderSize = 0;
            this.buttonGetPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGetPrevious.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGetPrevious.ForeColor = System.Drawing.Color.White;
            this.buttonGetPrevious.Location = new System.Drawing.Point(671, 443);
            this.buttonGetPrevious.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonGetPrevious.Name = "buttonGetPrevious";
            this.buttonGetPrevious.Size = new System.Drawing.Size(140, 28);
            this.buttonGetPrevious.TabIndex = 4;
            this.buttonGetPrevious.Text = "Página Anterior";
            this.buttonGetPrevious.UseVisualStyleBackColor = false;
            this.buttonGetPrevious.Click += new System.EventHandler(this.buttonGetPrevious_Click);
            // 
            // buttonNextPage
            // 
            this.buttonNextPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(18)))), ((int)(((byte)(33)))));
            this.buttonNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNextPage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonNextPage.ForeColor = System.Drawing.Color.White;
            this.buttonNextPage.Location = new System.Drawing.Point(815, 442);
            this.buttonNextPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonNextPage.Name = "buttonNextPage";
            this.buttonNextPage.Size = new System.Drawing.Size(140, 30);
            this.buttonNextPage.TabIndex = 5;
            this.buttonNextPage.Text = "Próxima Página";
            this.buttonNextPage.UseVisualStyleBackColor = false;
            this.buttonNextPage.Click += new System.EventHandler(this.buttonNextPage_Click);
            // 
            // buttonPostComments
            // 
            this.buttonPostComments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(18)))), ((int)(((byte)(33)))));
            this.buttonPostComments.Enabled = false;
            this.buttonPostComments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPostComments.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonPostComments.ForeColor = System.Drawing.Color.White;
            this.buttonPostComments.Location = new System.Drawing.Point(169, 443);
            this.buttonPostComments.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonPostComments.Name = "buttonPostComments";
            this.buttonPostComments.Size = new System.Drawing.Size(140, 28);
            this.buttonPostComments.TabIndex = 6;
            this.buttonPostComments.Text = "Comentar Posts";
            this.buttonPostComments.UseVisualStyleBackColor = false;
            this.buttonPostComments.Click += new System.EventHandler(this.buttonPostComments_Click);
            // 
            // japaoEmFoco
            // 
            this.japaoEmFoco.AutoSize = true;
            this.japaoEmFoco.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.japaoEmFoco.Location = new System.Drawing.Point(70, 35);
            this.japaoEmFoco.Name = "japaoEmFoco";
            this.japaoEmFoco.Size = new System.Drawing.Size(106, 16);
            this.japaoEmFoco.TabIndex = 8;
            this.japaoEmFoco.Text = "Japão em Foco";
            this.japaoEmFoco.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(32, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ações";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label2.Location = new System.Drawing.Point(674, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Navegação";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // buttonCSVReport
            // 
            this.buttonCSVReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCSVReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(18)))), ((int)(((byte)(33)))));
            this.buttonCSVReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCSVReport.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonCSVReport.ForeColor = System.Drawing.Color.White;
            this.buttonCSVReport.Location = new System.Drawing.Point(29, 516);
            this.buttonCSVReport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonCSVReport.Name = "buttonCSVReport";
            this.buttonCSVReport.Size = new System.Drawing.Size(136, 28);
            this.buttonCSVReport.TabIndex = 11;
            this.buttonCSVReport.Text = "Relatório .csv";
            this.buttonCSVReport.UseVisualStyleBackColor = false;
            this.buttonCSVReport.Click += new System.EventHandler(this.buttonCSVReport_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WebScrapingDemo.Properties.Resources.about;
            this.pictureBox4.Location = new System.Drawing.Point(944, 540);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(29, 21);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WebScrapingDemo.Properties.Resources.tenor;
            this.pictureBox3.Location = new System.Drawing.Point(29, 65);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(926, 345);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = global::WebScrapingDemo.Properties.Resources.unnamed;
            this.pictureBox2.Location = new System.Drawing.Point(314, 430);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WebScrapingDemo.Properties.Resources.logo_12;
            this.pictureBox1.Location = new System.Drawing.Point(29, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // processStatusLabel
            // 
            this.processStatusLabel.AutoSize = true;
            this.processStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.processStatusLabel.Location = new System.Drawing.Point(405, 452);
            this.processStatusLabel.Name = "processStatusLabel";
            this.processStatusLabel.Size = new System.Drawing.Size(43, 13);
            this.processStatusLabel.TabIndex = 15;
            this.processStatusLabel.Text = "Status";
            this.processStatusLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(985, 573);
            this.Controls.Add(this.processStatusLabel);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.buttonCSVReport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.japaoEmFoco);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonPostComments);
            this.Controls.Add(this.buttonNextPage);
            this.Controls.Add(this.buttonGetPrevious);
            this.Controls.Add(this.buttonSheetReport);
            this.Controls.Add(this.buttonTextReport);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Robô Japão em Foco";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonTextReport;
        private System.Windows.Forms.Button buttonSheetReport;
        private System.Windows.Forms.Button buttonGetPrevious;
        private System.Windows.Forms.Button buttonNextPage;
        private System.Windows.Forms.Button buttonPostComments;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtitulo;
        private System.Windows.Forms.DataGridViewLinkColumn Link;
        private System.Windows.Forms.DataGridViewImageColumn Imagem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label japaoEmFoco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCSVReport;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label processStatusLabel;
    }
}

