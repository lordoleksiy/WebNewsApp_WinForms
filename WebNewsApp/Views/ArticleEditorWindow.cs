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
using WebNewsApp.Controllers;
using WebNewsApp.Models;

namespace WebNewsApp.Views
{
    public partial class ArticleEditorWindow : Form
    {
        private ArticleViewModel article;
        private readonly ArticleManagerController _articleManagerController;
        private readonly UserManagerController _userManagerController;
        public ArticleEditorWindow()
        {
            IKernel kernel = Program.Kernel;
            var articleManagerService = kernel.Get<IArticleManagerService>();
            var userManagerService = kernel.Get<IUserManagerService>();
            var publishService = kernel.Get<IPublishManagerService>();
            _articleManagerController = new ArticleManagerController(articleManagerService, publishService);
            _userManagerController = new UserManagerController(userManagerService);
            InitializeComponent();
            LoadData();
            ArrangeData();
        }

        private void mainWindow_Click(object sender, EventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var header = this.headerBox.Text;
            var description = this.descriptionBox.Text;
            var categories = this.categoryListBox.SelectedItems;
            if (header.Length == 0 || categories.Count == 0 || article.Tags.Count == 0)
            {
                MessageBox.Show("Fill in fields");
                return;
            }
            if (categories.Count > 2)
            {
                MessageBox.Show("Too many categories");
                return;
            }
            if (article.Tags.Count > 5)
            {
                MessageBox.Show("Too many tags");
                return;
            }
            article.Header = header;
            article.ArticleText = description;
            foreach (var categoryName in categories) 
                article.Categories.Add(new CategoryViewModel() { Name = categoryName.ToString() });

            var res = _articleManagerController.CreateArticle(article);
            MessageBox.Show(res);   
        }
        private void LoadData()
        {
            
            var categories = _articleManagerController.LoadCategories();
            foreach (var category in categories)
            {
                this.categoryListBox.Items.Add(category.Name);
            }
        }

        private void ArrangeData()
        {
            article = new ArticleViewModel
            {
                Authors = new List<UserViewModel>(),
                Tags = new List<TagViewModel>(),
                Categories = new List<CategoryViewModel>()
            };
            article.Authors.Add(AccountController.Get());
            this.authorListBox.Items.Add(article.Authors.First().Login);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var userLogin = this.authorBox.Text;
            if (userLogin == null)
            {
                MessageBox.Show("Fill the fill for user login!");
                return;
            }
            var user = _userManagerController.FindUserByLogin(userLogin);
            if (user.ErrorStatus != null)
            {
                MessageBox.Show("No user with such login!");
                return;
            }
            if (article.Authors.Any(a => a.Login.Equals(userLogin)))
            {
                MessageBox.Show("Author is already addded!");
                return;
            }
            this.authorBox.Clear();
            article.Authors.Add(user);
            this.authorListBox.Items.Add(user.Login);
        }

        private void addTagButton_Click(object sender, EventArgs e)
        {
            var tagName = this.tagBox.Text;
            if (tagName == null || this.tagListBox.Items.Contains(tagName))
            {
                MessageBox.Show("Incorrect Tag!");
                return;
            }

            this.tagBox.Clear();
            article.Tags.Add(
                new TagViewModel()
                {
                    Name = tagName
                }) ;

            this.tagListBox.Items.Add(this.tagBox.Text);
        }

        private void tagListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tagName = this.tagListBox.SelectedItem;
            if (tagName != null)
            {
                article.Tags.Remove(article.Tags.Find(a => a.Name.Equals(tagName)));
                this.tagListBox.Items.Remove(tagName);
            }
        }

        private void authorListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var login = this.authorListBox.SelectedItem;
            if (login != null && !login.Equals(AccountController.Get().Login))
            {
                if (!this.authorListBox.Items.Contains(login)) { 
                    article.Authors.Remove(article.Authors.Find(a => a.Login.Equals(login)));
                    this.authorListBox.Items.Remove(login);
                }
            }
        }
    }
}
