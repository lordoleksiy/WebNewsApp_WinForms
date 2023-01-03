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
        }

        private void InitializeRegisteredUser()
        {

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

        private IEnumerable<ArticleViewModel> loadArticles()
        {
            return null;
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
        private void LoadData()
        {

        }
    }
}
