using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebNewsApp.Models;

namespace WebNewsApp.Views
{
    public partial class ArticleViewerWindow : Form
    {
        public ArticleViewerWindow(ArticleViewModel article)
        {
            InitializeComponent();
            InitializeData(article);
        }

        private void mainWindow_Click(object sender, EventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void InitializeData(ArticleViewModel article)
        {
            this.Header.Text = article.Header;
            this.publishedTime.Text = article.PublishedTime.ToString();
            this.descriptionBox.Text = article.ArticleText;
            foreach (var tag in article.Tags)
            {
                this.tagListBox.Items.Add(tag.Name);
            }
            foreach (var category in article.Categories)
            {
                this.categoryListBox.Items.Add(category.Name);
            }
            foreach (var user in article.Authors)
            {
                this.authorListBox.Items.Add(user.Login);
            }
        }
    }
}
