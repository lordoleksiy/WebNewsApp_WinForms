namespace WebNewsApp.Views
{
    partial class ArticleEditorWindow
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
            this.addAuthorButton = new System.Windows.Forms.Button();
            this.addTagButton = new System.Windows.Forms.Button();
            this.tagListBox = new System.Windows.Forms.ListBox();
            this.authorListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.authorBox = new System.Windows.Forms.TextBox();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.categoryListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tagBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.headerBox = new System.Windows.Forms.TextBox();
            this.mainWindow = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.addAuthorButton);
            this.panel1.Controls.Add(this.addTagButton);
            this.panel1.Controls.Add(this.tagListBox);
            this.panel1.Controls.Add(this.authorListBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.authorBox);
            this.panel1.Controls.Add(this.descriptionBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.categoryListBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tagBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.headerBox);
            this.panel1.Controls.Add(this.mainWindow);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 453);
            this.panel1.TabIndex = 4;
            // 
            // addAuthorButton
            // 
            this.addAuthorButton.Location = new System.Drawing.Point(303, 330);
            this.addAuthorButton.Name = "addAuthorButton";
            this.addAuthorButton.Size = new System.Drawing.Size(75, 23);
            this.addAuthorButton.TabIndex = 36;
            this.addAuthorButton.Text = "Add";
            this.addAuthorButton.UseVisualStyleBackColor = true;
            this.addAuthorButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // addTagButton
            // 
            this.addTagButton.Location = new System.Drawing.Point(303, 112);
            this.addTagButton.Name = "addTagButton";
            this.addTagButton.Size = new System.Drawing.Size(75, 23);
            this.addTagButton.TabIndex = 35;
            this.addTagButton.Text = "Add";
            this.addTagButton.UseVisualStyleBackColor = true;
            this.addTagButton.Click += new System.EventHandler(this.addTagButton_Click);
            // 
            // tagListBox
            // 
            this.tagListBox.FormattingEnabled = true;
            this.tagListBox.ItemHeight = 16;
            this.tagListBox.Location = new System.Drawing.Point(110, 140);
            this.tagListBox.Name = "tagListBox";
            this.tagListBox.ScrollAlwaysVisible = true;
            this.tagListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.tagListBox.Size = new System.Drawing.Size(177, 84);
            this.tagListBox.TabIndex = 34;
            this.tagListBox.SelectedIndexChanged += new System.EventHandler(this.tagListBox_SelectedIndexChanged);
            // 
            // authorListBox
            // 
            this.authorListBox.FormattingEnabled = true;
            this.authorListBox.ItemHeight = 16;
            this.authorListBox.Location = new System.Drawing.Point(110, 355);
            this.authorListBox.Name = "authorListBox";
            this.authorListBox.ScrollAlwaysVisible = true;
            this.authorListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.authorListBox.Size = new System.Drawing.Size(177, 84);
            this.authorListBox.TabIndex = 33;
            this.authorListBox.SelectedIndexChanged += new System.EventHandler(this.authorListBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(9, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 26);
            this.label6.TabIndex = 31;
            this.label6.Text = "Add author:";
            // 
            // authorBox
            // 
            this.authorBox.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.authorBox.Location = new System.Drawing.Point(110, 323);
            this.authorBox.Name = "authorBox";
            this.authorBox.Size = new System.Drawing.Size(177, 30);
            this.authorBox.TabIndex = 30;
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(448, 109);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.descriptionBox.Size = new System.Drawing.Size(340, 256);
            this.descriptionBox.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Banner", 10.8F);
            this.label4.Location = new System.Drawing.Point(575, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 26);
            this.label4.TabIndex = 28;
            this.label4.Text = "Text:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(327, 400);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(165, 39);
            this.saveButton.TabIndex = 26;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // categoryListBox
            // 
            this.categoryListBox.FormattingEnabled = true;
            this.categoryListBox.ItemHeight = 16;
            this.categoryListBox.Location = new System.Drawing.Point(110, 229);
            this.categoryListBox.Name = "categoryListBox";
            this.categoryListBox.ScrollAlwaysVisible = true;
            this.categoryListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.categoryListBox.Size = new System.Drawing.Size(177, 84);
            this.categoryListBox.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 26);
            this.label5.TabIndex = 24;
            this.label5.Text = "Tags:";
            // 
            // tagBox
            // 
            this.tagBox.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tagBox.Location = new System.Drawing.Point(110, 109);
            this.tagBox.Name = "tagBox";
            this.tagBox.Size = new System.Drawing.Size(177, 30);
            this.tagBox.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 26);
            this.label3.TabIndex = 22;
            this.label3.Text = "Categories: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 26);
            this.label2.TabIndex = 21;
            this.label2.Text = "Header: ";
            // 
            // headerBox
            // 
            this.headerBox.Font = new System.Drawing.Font("Sitka Banner", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headerBox.Location = new System.Drawing.Point(89, 68);
            this.headerBox.Name = "headerBox";
            this.headerBox.Size = new System.Drawing.Size(300, 30);
            this.headerBox.TabIndex = 19;
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
            this.mainWindow.TabIndex = 18;
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
            // ArticleEditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "ArticleEditorWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArticleEditorWindow";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label mainWindow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tagBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox headerBox;
        private System.Windows.Forms.ListBox categoryListBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox authorBox;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox tagListBox;
        private System.Windows.Forms.ListBox authorListBox;
        private System.Windows.Forms.Button addAuthorButton;
        private System.Windows.Forms.Button addTagButton;
    }
}