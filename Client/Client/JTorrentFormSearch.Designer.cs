namespace Client
{
    partial class JTorrentFormSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JTorrentFormSearch));
            this.searchForm_txtSearch = new System.Windows.Forms.TextBox();
            this.searchForm_btnSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.browseFile = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.user = new System.Windows.Forms.Label();
            this.results = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Label();
            this.upload = new System.Windows.Forms.Label();
            this.listViewSearch = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // searchForm_txtSearch
            // 
            this.searchForm_txtSearch.Location = new System.Drawing.Point(24, 190);
            this.searchForm_txtSearch.Name = "searchForm_txtSearch";
            this.searchForm_txtSearch.Size = new System.Drawing.Size(387, 20);
            this.searchForm_txtSearch.TabIndex = 0;
            this.searchForm_txtSearch.TextChanged += new System.EventHandler(this.searchForm_txtSearch_TextChanged);
            this.searchForm_txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchForm_txtSearch_KeyDown);
            // 
            // searchForm_btnSearch
            // 
            this.searchForm_btnSearch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchForm_btnSearch.ForeColor = System.Drawing.Color.DimGray;
            this.searchForm_btnSearch.Location = new System.Drawing.Point(433, 189);
            this.searchForm_btnSearch.Name = "searchForm_btnSearch";
            this.searchForm_btnSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.searchForm_btnSearch.Size = new System.Drawing.Size(81, 21);
            this.searchForm_btnSearch.TabIndex = 1;
            this.searchForm_btnSearch.Text = "Search";
            this.searchForm_btnSearch.UseVisualStyleBackColor = true;
            this.searchForm_btnSearch.Click += new System.EventHandler(this.searchForm_btnSearch_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DimGray;
            this.button1.Location = new System.Drawing.Point(431, 292);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 21);
            this.button1.TabIndex = 3;
            this.button1.Text = "Upload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // browseFile
            // 
            this.browseFile.Location = new System.Drawing.Point(24, 293);
            this.browseFile.Name = "browseFile";
            this.browseFile.Size = new System.Drawing.Size(271, 20);
            this.browseFile.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DimGray;
            this.button2.Location = new System.Drawing.Point(330, 292);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 21);
            this.button2.TabIndex = 5;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // logout
            // 
            this.logout.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout.ForeColor = System.Drawing.Color.DimGray;
            this.logout.Location = new System.Drawing.Point(839, 12);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(68, 22);
            this.logout.TabIndex = 6;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.button3_Click);
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.BackColor = System.Drawing.Color.Transparent;
            this.user.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.Location = new System.Drawing.Point(779, 17);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(54, 13);
            this.user.TabIndex = 7;
            this.user.Text = "Hi User";
            this.user.Click += new System.EventHandler(this.label1_Click);
            // 
            // results
            // 
            this.results.AutoSize = true;
            this.results.BackColor = System.Drawing.Color.Transparent;
            this.results.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.results.ForeColor = System.Drawing.Color.DimGray;
            this.results.Location = new System.Drawing.Point(530, 71);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(66, 16);
            this.results.TabIndex = 10;
            this.results.Text = "Results:";
            // 
            // search
            // 
            this.search.AutoSize = true;
            this.search.BackColor = System.Drawing.Color.Transparent;
            this.search.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search.ForeColor = System.Drawing.Color.DimGray;
            this.search.Location = new System.Drawing.Point(21, 158);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(58, 16);
            this.search.TabIndex = 11;
            this.search.Text = "Search";
            this.search.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // upload
            // 
            this.upload.AutoSize = true;
            this.upload.BackColor = System.Drawing.Color.Transparent;
            this.upload.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upload.ForeColor = System.Drawing.Color.DimGray;
            this.upload.Location = new System.Drawing.Point(21, 265);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(58, 16);
            this.upload.TabIndex = 12;
            this.upload.Text = "Upload";
            this.upload.Click += new System.EventHandler(this.label2_Click);
            // 
            // listViewSearch
            // 
            this.listViewSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listViewSearch.FullRowSelect = true;
            this.listViewSearch.GridLines = true;
            this.listViewSearch.Location = new System.Drawing.Point(533, 97);
            this.listViewSearch.Name = "listViewSearch";
            this.listViewSearch.Size = new System.Drawing.Size(374, 292);
            this.listViewSearch.TabIndex = 13;
            this.listViewSearch.UseCompatibleStateImageBehavior = false;
            this.listViewSearch.View = System.Windows.Forms.View.Details;
            this.listViewSearch.DoubleClick += new System.EventHandler(this.listViewSearch_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 37;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Username";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Path";
            this.columnHeader3.Width = 209;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Dimension";
            this.columnHeader4.Width = 63;
            // 
            // JTorrentFormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Client.Properties.Resources.main3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(925, 401);
            this.Controls.Add(this.listViewSearch);
            this.Controls.Add(this.upload);
            this.Controls.Add(this.search);
            this.Controls.Add(this.results);
            this.Controls.Add(this.user);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.browseFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchForm_btnSearch);
            this.Controls.Add(this.searchForm_txtSearch);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JTorrentFormSearch";
            this.Text = "JTorrent";
            this.Load += new System.EventHandler(this.JTorrentFormSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchForm_txtSearch;
        private System.Windows.Forms.Button searchForm_btnSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox browseFile;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Label results;
        private System.Windows.Forms.Label search;
        private System.Windows.Forms.Label upload;
        private System.Windows.Forms.ListView listViewSearch;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}