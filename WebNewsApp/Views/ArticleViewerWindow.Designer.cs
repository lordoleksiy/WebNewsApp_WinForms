namespace WebNewsApp.Views
{
    partial class ArticleViewerWindow
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
            this.mainWindow = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tagListBox = new System.Windows.Forms.ListBox();
            this.categoryListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.authorListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Header = new System.Windows.Forms.Label();
            this.publishedTime = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.publishedTime);
            this.panel1.Controls.Add(this.Header);
            this.panel1.Controls.Add(this.descriptionBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.authorListBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tagListBox);
            this.panel1.Controls.Add(this.categoryListBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.mainWindow);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 453);
            this.panel1.TabIndex = 4;
            // 
            // mainWindow
            // 
            this.mainWindow.AutoSize = true;
            this.mainWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainWindow.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainWindow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.mainWindow.Location = new System.Drawing.Point(622, 10);
            this.mainWindow.Name = "mainWindow";
            this.mainWindow.Size = new System.Drawing.Size(166, 26);
            this.mainWindow.TabIndex = 32;
            this.mainWindow.Text = "Back To Main Window";
            this.mainWindow.Click += new System.EventHandler(this.mainWindow_Click);
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
            // tagListBox
            // 
            this.tagListBox.Enabled = false;
            this.tagListBox.FormattingEnabled = true;
            this.tagListBox.ItemHeight = 16;
            this.tagListBox.Location = new System.Drawing.Point(125, 265);
            this.tagListBox.Name = "tagListBox";
            this.tagListBox.ScrollAlwaysVisible = true;
            this.tagListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.tagListBox.Size = new System.Drawing.Size(177, 84);
            this.tagListBox.TabIndex = 38;
            // 
            // categoryListBox
            // 
            this.categoryListBox.Enabled = false;
            this.categoryListBox.FormattingEnabled = true;
            this.categoryListBox.ItemHeight = 16;
            this.categoryListBox.Location = new System.Drawing.Point(125, 355);
            this.categoryListBox.Name = "categoryListBox";
            this.categoryListBox.ScrollAlwaysVisible = true;
            this.categoryListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.categoryListBox.Size = new System.Drawing.Size(177, 84);
            this.categoryListBox.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(27, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 26);
            this.label5.TabIndex = 36;
            this.label5.Text = "Tags:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(27, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 26);
            this.label3.TabIndex = 35;
            this.label3.Text = "Categories: ";
            // 
            // authorListBox
            // 
            this.authorListBox.Enabled = false;
            this.authorListBox.FormattingEnabled = true;
            this.authorListBox.ItemHeight = 16;
            this.authorListBox.Location = new System.Drawing.Point(125, 173);
            this.authorListBox.Name = "authorListBox";
            this.authorListBox.ScrollAlwaysVisible = true;
            this.authorListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.authorListBox.Size = new System.Drawing.Size(177, 84);
            this.authorListBox.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(27, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 26);
            this.label6.TabIndex = 39;
            this.label6.Text = "Authors:";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Enabled = false;
            this.descriptionBox.Location = new System.Drawing.Point(408, 165);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.descriptionBox.Size = new System.Drawing.Size(340, 269);
            this.descriptionBox.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Banner", 10.8F);
            this.label4.Location = new System.Drawing.Point(550, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 26);
            this.label4.TabIndex = 30;
            this.label4.Text = "Text:";
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Sitka Banner", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Header.Location = new System.Drawing.Point(344, 76);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(92, 39);
            this.Header.TabIndex = 41;
            this.Header.Text = "Header";
            // 
            // publishedTime
            // 
            this.publishedTime.AutoSize = true;
            this.publishedTime.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.publishedTime.Location = new System.Drawing.Point(76, 124);
            this.publishedTime.Name = "publishedTime";
            this.publishedTime.Size = new System.Drawing.Size(114, 26);
            this.publishedTime.TabIndex = 42;
            this.publishedTime.Text = "PublishedTime";
            // 
            // ArticleViewerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "ArticleViewerWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArticleViewer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label mainWindow;
        private System.Windows.Forms.ListBox tagListBox;
        private System.Windows.Forms.ListBox categoryListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox authorListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label publishedTime;
        private System.Windows.Forms.Label Header;
    }
}