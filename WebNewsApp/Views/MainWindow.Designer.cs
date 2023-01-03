namespace WebNewsApp.Views
{
    partial class MainWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.findComboBox = new System.Windows.Forms.ComboBox();
            this.createButton = new System.Windows.Forms.Button();
            this.newsList = new System.Windows.Forms.ListView();
            this.Header = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Authors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Categories = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AccountLink = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.resetButton);
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Controls.Add(this.inputBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.findComboBox);
            this.panel1.Controls.Add(this.createButton);
            this.panel1.Controls.Add(this.newsList);
            this.panel1.Controls.Add(this.AccountLink);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 453);
            this.panel1.TabIndex = 3;
            // 
            // inputBox
            // 
            this.inputBox.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputBox.Location = new System.Drawing.Point(146, 87);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(162, 30);
            this.inputBox.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Banner", 10.8F);
            this.label3.Location = new System.Drawing.Point(55, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 26);
            this.label3.TabIndex = 11;
            this.label3.Text = "Find By:";
            // 
            // findComboBox
            // 
            this.findComboBox.Font = new System.Drawing.Font("Sitka Banner", 10.8F);
            this.findComboBox.FormattingEnabled = true;
            this.findComboBox.Items.AddRange(new object[] {
            "Header",
            "Author",
            "Tag",
            "Category",
            "Date"});
            this.findComboBox.Location = new System.Drawing.Point(341, 84);
            this.findComboBox.Name = "findComboBox";
            this.findComboBox.Size = new System.Drawing.Size(139, 34);
            this.findComboBox.TabIndex = 10;
            // 
            // createButton
            // 
            this.createButton.Font = new System.Drawing.Font("Sitka Banner", 10.8F);
            this.createButton.Location = new System.Drawing.Point(326, 397);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(167, 42);
            this.createButton.TabIndex = 9;
            this.createButton.Text = "Create article";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // newsList
            // 
            this.newsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Header,
            this.Date,
            this.Authors,
            this.Tags,
            this.Categories});
            this.newsList.Font = new System.Drawing.Font("Sitka Banner", 10.8F);
            this.newsList.HideSelection = false;
            this.newsList.Location = new System.Drawing.Point(57, 124);
            this.newsList.MultiSelect = false;
            this.newsList.Name = "newsList";
            this.newsList.Size = new System.Drawing.Size(687, 252);
            this.newsList.TabIndex = 8;
            this.newsList.UseCompatibleStateImageBehavior = false;
            this.newsList.View = System.Windows.Forms.View.Details;
            // 
            // Header
            // 
            this.Header.Text = "Header";
            this.Header.Width = 159;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 94;
            // 
            // Authors
            // 
            this.Authors.Text = "Authors";
            this.Authors.Width = 137;
            // 
            // Tags
            // 
            this.Tags.Text = "Tags";
            this.Tags.Width = 149;
            // 
            // Categories
            // 
            this.Categories.Text = "Categories";
            this.Categories.Width = 224;
            // 
            // AccountLink
            // 
            this.AccountLink.AutoSize = true;
            this.AccountLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AccountLink.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AccountLink.ForeColor = System.Drawing.SystemColors.WindowText;
            this.AccountLink.Location = new System.Drawing.Point(687, 10);
            this.AccountLink.Name = "AccountLink";
            this.AccountLink.Size = new System.Drawing.Size(102, 26);
            this.AccountLink.TabIndex = 4;
            this.AccountLink.Text = "Your account";
            this.AccountLink.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(800, 65);
            this.label1.TabIndex = 3;
            this.label1.Text = "Web News Application";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Sitka Banner", 10.8F);
            this.searchButton.Location = new System.Drawing.Point(524, 83);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 35);
            this.searchButton.TabIndex = 25;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Sitka Banner", 10.8F);
            this.resetButton.Location = new System.Drawing.Point(644, 82);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(100, 35);
            this.resetButton.TabIndex = 26;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainWindow";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label AccountLink;
        private System.Windows.Forms.ListView newsList;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ColumnHeader Header;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Authors;
        private System.Windows.Forms.ColumnHeader Tags;
        private System.Windows.Forms.ColumnHeader Categories;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox findComboBox;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button searchButton;
    }
}