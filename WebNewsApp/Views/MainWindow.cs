using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.BLL.Services;
using WebNewsApp.Controllers;
using WebNewsApp.Models;

namespace WebNewsApp.Views
{
    public partial class MainWindow : Form
    {
        private static ArticleManagerController _articleController;
        private IEnumerable<ArticleViewModel> _articles;
        private bool account = false;
        static MainWindow()
        {
            IKernel kernel = Program.Kernel;
            var articleService = kernel.Get<IArticleManagerService>();
            var publishService = kernel.Get<IPublishManagerService>();
            _articleController = new ArticleManagerController(articleService, publishService);   
        }
        public MainWindow()
        {
            InitializeComponent();
            var Account = AccountController.Get();
            if (Account != null)
            {
                this.AccountLink.Text = Account.Login;
            }
            _articles = _articleController.GetArticles();
            ShowArticles();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (AccountController.Get() == null)
            {
                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();
            }
            else
            {
                OwnAccountWindow ownAccountWindow = new OwnAccountWindow();
                ownAccountWindow.Show();
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (AccountController.Get() != null)
            {
                this.Hide();
                ArticleEditorWindow articleEditorWindow = new ArticleEditorWindow();
                articleEditorWindow.Show();
            }
            else
            {
                MessageBox.Show("Only registered users can create articles.");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var choice = this.findComboBox.SelectedItem;
            var text = this.inputBox.Text;
            if (choice == null || (text.Length == 0 && !choice.Equals("Date")))
            {
                MessageBox.Show("Fill in fields");
                return;
            }
            if (choice.Equals("Author"))
            {
                var res = _articleController.GetArticlesByAuthor(text);
                if (res == null)
                {
                    MessageBox.Show("No user with such login");
                    return;
                }
                _articles = res;
            }
            else if (choice.Equals("Header"))
            {
                var res = _articleController.GetArticlesByHeader(text);
                _articles = res;
            }
            else if (choice.Equals("Category"))
            {
                var res = _articleController.GetArticlesByCategory(text);
                if (res == null)
                {
                    MessageBox.Show("No such category");
                    return;
                }
                _articles = res;
            }
            else if (choice.Equals("Tag"))
            {
                var res = _articleController.GetArticlesByTag(text);
                if (res == null)
                {
                    MessageBox.Show("No such tag");
                    return;
                }
                _articles = res;
            }
            else
            {
                var date1 = this.dateTimeStart.Text;
                var date2 = this.dateTimeEnd.Text;
                _articles = _articleController.GetArticlesByTime(date1, date2);
            }
            account = false;
            ShowArticles();
        }

        private void ShowArticles()
        {
            this.newsList.Items.Clear();
            foreach (var article in _articles)
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Text = article.Header;
                string categories = "";
                string authors = "";
                string tags = "";
                article.Categories.ForEach(category => categories += $"{category.Name}; ");
                article.Authors.ForEach(author => authors += $"{author.Login}; ");
                article.Tags.ForEach(tag => tags += $"{tag.Name}; ");

                listItem.SubItems.Add(article.PublishedTime.ToString());
                listItem.SubItems.Add(authors);
                listItem.SubItems.Add(tags);
                listItem.SubItems.Add(categories);

                this.newsList.Items.Add(listItem);

            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this.inputBox.Clear();
            account = false;
            _articles = _articleController.GetArticles();
            ShowArticles();
        }

        private void findComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.findComboBox.SelectedItem.Equals("Date"))
            {
                this.dateTimeStart.Enabled = true;
                this.dateTimeEnd.Enabled = true;
            }
            else
            {
                this.dateTimeStart.Enabled = false;
                this.dateTimeEnd.Enabled = false;
            }
        }

        private void userArticles_Click(object sender, EventArgs e)
        {
            var user = AccountController.Get();
            if (user != null)
            {
                account = true;
                _articles = _articleController.GetArticlesByAuthor(user.Login);
                ShowArticles();
            }
            else
            {
                MessageBox.Show("You are not registered!");
            }
        }

        private void newsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var article = _articles.ToList()[this.newsList.SelectedIndices[0]];
            article.ArticleText = _articleController.LoadTextByArticleId(article.Id);
            if (account)
            {
                ArticleEditorWindow editorWindow = new ArticleEditorWindow(article);
                editorWindow.Show();
                this.Hide();
            }
            else
            {
                ArticleViewerWindow articleViewer = new ArticleViewerWindow(article);
                articleViewer.Show();
                this.Hide();
            }
        }
    }
}
