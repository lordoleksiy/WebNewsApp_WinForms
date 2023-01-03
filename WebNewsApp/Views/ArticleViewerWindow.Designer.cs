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
            this.userArticles = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mainWindow = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.mainWindow);
            this.panel1.Controls.Add(this.userArticles);
            this.panel1.Controls.Add(this.createButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 453);
            this.panel1.TabIndex = 4;
            // 
            // userArticles
            // 
            this.userArticles.Font = new System.Drawing.Font("Sitka Banner", 10.8F);
            this.userArticles.Location = new System.Drawing.Point(553, 412);
            this.userArticles.Name = "userArticles";
            this.userArticles.Size = new System.Drawing.Size(152, 35);
            this.userArticles.TabIndex = 31;
            this.userArticles.Text = "My Articles";
            this.userArticles.UseVisualStyleBackColor = true;
            // 
            // createButton
            // 
            this.createButton.Font = new System.Drawing.Font("Sitka Banner", 10.8F);
            this.createButton.Location = new System.Drawing.Point(71, 412);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(152, 35);
            this.createButton.TabIndex = 9;
            this.createButton.Text = "Create article";
            this.createButton.UseVisualStyleBackColor = true;
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
            // ArticleViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "ArticleViewer";
            this.Text = "ArticleViewer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button userArticles;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label mainWindow;
    }
}