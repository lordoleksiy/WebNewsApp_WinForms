using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.Controllers;
using WebNewsApp.Models;
using WebNewsApp.Views;

namespace WebNewsApp.Presenters
{
    public class ArticleViewerPresenter
    {
        private readonly ArticleViewerWindow _window;
        private readonly ArticleViewModel _article;
        public ArticleViewerPresenter(ArticleViewerWindow window, ArticleViewModel article) {
            _window = window;
            _window.Show();
            _article = article;
            _window.backToMainWindowClicked += mainWindow_Click;
            InitializeData();
        }

        private void mainWindow_Click(object sender, EventArgs e)
        {
            _window.Close();
            new MainPresenter(new MainWindow());
            
        }

        private void InitializeData()
        {
            _window.Header = _article.Header;
            _window.PublishedTime = _article.PublishedTime.ToString();
            _window.Description = _article.ArticleText;
            var tagNames = _article.Tags.Select(t => t.Name).ToList();
            var categoryNames = _article.Categories.Select(t => t.Name).ToList();
            var authorNames = _article.Authors.Select(t => t.Name).ToList();
            _window.TagList = tagNames;
            _window.Categories = categoryNames;
            _window.Authors = authorNames;
        }
    }
}
