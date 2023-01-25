using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using WebNewsApp.BLL.DTO;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.Models;
using WebNewsApp.Presenters;
using WebNewsApp.Views;

namespace WebNewsApp.Controllers
{
    public class MainPresenter
    {
        private IArticleManagerService _articleService;
        private readonly MainWindow _window;
        private IEnumerable<ArticleViewModel> _articles;
        private bool account = false;

        public MainPresenter(MainWindow window)
        {
            IKernel kernel = Program.Kernel;
            _articleService = kernel.Get<IArticleManagerService>();
            _window = window;
            _window.Show();

            _window.onAccountClick += AccountLinkClick;
            _window.onSearchClick += SearchButtonClick;
            _window.onResetClick += ResetButtonClick;
            _window.onCreateClick+= CreateButtonClick;
            _window.onFindChoice += OnSearchChanged;
            _window.onArticleClick += OnArticleClick;
            _window.onMyArticlesClick += UserArticlesClick;

            var Account = AccountPresenter.Get();
            if (Account != null)
            {
                _window.AccountLinkText = Account.Login;
            }
            _articles = convertArticles(_articleService.GetAll());
            ShowArticles();
        }

        private void AccountLinkClick(object sender, EventArgs e)
        {
            _window.Hide();
            if (AccountPresenter.Get() == null)
            {
                new AuthorizationPresenter(new AuthorizationWindow());
            }
            else
            {
                new OwnAccountPresenter(new OwnAccountWindow());
            }
        }

        private void CreateButtonClick(object sender, EventArgs e)
        {
            if (AccountPresenter.Get() != null)
            {
                _window.Hide();
                new ArticleEditorPresenter(new ArticleEditorWindow());
            }
            else
            {
                MessageBox.Show("Only registered users can create articles.");
            }
        }

        private void SearchButtonClick(object sender, EventArgs e)
        {
            var choice = _window.ChoiceItem;
            var text = _window.InputText;
            if (choice == null || (text.Length == 0 && !choice.Equals("Date")))
            {
                MessageBox.Show("Fill in fields");
                return;
            }
            try
            {
                if (choice.Equals("Author"))
                {
                    _articles = convertArticles(_articleService.FindByUserLogin(text));
                }
                else if (choice.Equals("Header"))
                {
                    _articles = convertArticles(_articleService.FindByHeader(text));
                }
                else if (choice.Equals("Category"))
                {
                    _articles = convertArticles(_articleService.FindByCategoryName(text));
                }
                else if (choice.Equals("Tag"))
                {
                    _articles = convertArticles(_articleService.FindByTagName(text));
                }
                else
                {
                    _articles = convertArticles(_articleService.FindByTime(_window.StartTime, _window.EndTime));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            account = false;
            ShowArticles();
        }

        private void ResetButtonClick(object sender, EventArgs e)
        {
            _window.InputText = "";
            account = false;
            _articles = convertArticles(_articleService.GetAll());
            ShowArticles();
        }

        private void OnSearchChanged(object sender, EventArgs e)
        {
            if (_window.ChoiceItem.Equals("Date"))
            {
                _window.EnableDatePicker();
            }
            else
            {
                _window.DisableDatePicker();
            }
        }

        private void UserArticlesClick(object sender, EventArgs e)
        {
            var user = AccountPresenter.Get();
            if (user != null)
            {
                account = true;
                _articles = convertArticles(_articleService.FindByUserLogin(user.Login));
                ShowArticles();
            }
            else
            {
                MessageBox.Show("You are not registered!");
            }
        }

        private void OnArticleClick(object sender, EventArgs e)
        {
            
            var article = _articles.ToList()[_window.SelectedArticleId];
            article.ArticleText = LoadTextByArticleId(article.Id);
            if (account)
            {
                new ArticleEditorPresenter(new ArticleEditorWindow(), article);
            }
            else
            {
                new ArticleViewerPresenter(new ArticleViewerWindow(), article);
            }
            _window.Hide();
        }

        private void ShowArticles()
        {
            _window.ClearNews();
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

                _window.AddNews(listItem);

            }
        }

        public string LoadTextByArticleId(int id)
        {
            return _articleService.GetTextByArticleId(id);
        }

        private IEnumerable<ArticleViewModel> convertArticles(IEnumerable<ArticleDTO> articlesDTO)
        {
            return articlesDTO.Select(article => new ArticleViewModel()
            {
                Id = article.Id,
                Header = article.Header,
                PublishedTime = article.PublishedTime,
                Authors = new List<UserViewModel>(article.AuthorDTOs.Select(a => 
                new UserViewModel() 
                { 
                    Id = a.Id, 
                    Login = a.Login,
                    Email = a.Email,
                    Name = a.Name,
                    Surname = a.Surname,
                })),
                Tags = new List<TagViewModel>(article.TagDTOs.Select(a => 
                new TagViewModel() { Id =  a.Id, Name = a.Name})),
                Categories = new List<CategoryViewModel>(article.CategoryDTOs.Select(a =>
                new CategoryViewModel() { Id = a.Id, Name = a.Name}))
            });
        }
    }
}
