using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using WebNewsApp.BLL.DTO;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.BLL.Services;
using WebNewsApp.Controllers;
using WebNewsApp.Models;
using WebNewsApp.Views;

namespace WebNewsApp.Presenters
{
    public class ArticleEditorPresenter
    {
        private readonly ArticleEditorWindow _window;
        private ArticleViewModel _article;
        private IArticleManagerService _articleService;
        private IPublishManagerService _publishService;
        private IUserManagerService _userService;
        public ArticleEditorPresenter(ArticleEditorWindow window) {
            _window = window;
            _window.Show();
            StartUpSetUp();
            ArrangeData();
        }

        public ArticleEditorPresenter(ArticleEditorWindow window, ArticleViewModel model)
        {
            _article = model;
            _window = window;
            _window.Show();
            StartUpSetUp();
            UpdateVisualData();
        }

        private void StartUpSetUp()
        {
            IKernel kernel = Program.Kernel;
            _articleService = kernel.Get<IArticleManagerService>();
            _userService = kernel.Get<IUserManagerService>();
            _publishService = kernel.Get<IPublishManagerService>();

            _window.onBackToMainWindowClicked += BackToMainWindow;
            _window.onSaveClicked += SaveButtonClick;
            _window.onDeleteClicked += DeleteLink_Click;
            _window.onAddAuthorClicked += AddAuthorClick;
            _window.onAddTagClicked += AddTagClick;
            _window.onAuthorChecked += AuthorIsSelected;
            _window.onTagChecked += TagIsSelected;

            LoadData();
        }

        private void BackToMainWindow(object sender, EventArgs e)
        {
            _window.Close();
            new MainPresenter(new MainWindow());
            
        }

        private void SaveButtonClick(object sender, EventArgs e)
        {
            var header = _window.Header;
            var description = _window.Description;
            var categories = _window.SelectedCategories.ToList();
            if (header.Length == 0 || categories.Count == 0 || _article.Tags.Count == 0)
            {
                MessageBox.Show("Fill in fields");
                return;
            }
            if (categories.Count > 2)
            {
                MessageBox.Show("Too many categories");
                return;
            }
            if (_article.Tags.Count > 5)
            {
                MessageBox.Show("Too many tags");
                return;
            }
            _article.Header = header;
            _article.ArticleText = description;
            foreach (var categoryName in categories)
                _article.Categories.Add(new CategoryViewModel() { Name = categoryName.ToString() });

            if (_article.Id == -1)
            {
                var res = CreateArticle(_article);
                if (res == null)
                {
                    MessageBox.Show("Article is created!");
                    GetArticleId(ref _article);
                }
                else
                {
                    MessageBox.Show(res);
                }
            }
            else
            {
                var res = UpdateArticle(_article);
                if (res == null)
                {
                    MessageBox.Show("Article is updated!");
                }
                else
                {
                    MessageBox.Show(res);
                }
            }
        }
        private void LoadData()
        {
            var categoriesDTO = _articleService.GetAllCategories();
            var categories = categoriesDTO.Select(a => new CategoryViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description
            });
            _window.Categories = categories.Select(a => a.Name);
        }

        private void ArrangeData()
        {
            _article = new ArticleViewModel
            {
                Id = -1,
                Authors = new List<UserViewModel>(),
                Tags = new List<TagViewModel>(),
                Categories = new List<CategoryViewModel>()
            };
            _article.Authors.Add(AccountPresenter.Get());
            _window.Authors = _article.Authors.Select(t => t.Name).ToList();
        }

        private void AddAuthorClick(object sender, EventArgs e)
        {
            var userLogin = _window.AuthorText;
            UserViewModel user = new UserViewModel();

            try
            {
                var userDTO = _userService.FindByLogin(userLogin);
                user = new UserViewModel()
                {
                    Id = userDTO.Id,
                    Login = userDTO.Login,
                    Email = userDTO.Email,
                    Name = userDTO.Name,
                    Surname = userDTO.Surname,
                    Description = userDTO.Description
                };
                if (_article.Authors.Any(a => a.Login.Equals(userLogin)))
                {
                    MessageBox.Show("Author is already addded!");
                    return;
                }
                _article.Authors.Add(user);
                _window.AddUser(user.Login);
                _window.AuthorText = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddTagClick(object sender, EventArgs e)
        {
            var tagName = _window.TagText;
            if (tagName == null || _window.TagList.Contains(tagName))
            {
                MessageBox.Show("Incorrect Tag!");
                return;
            }

            _article.Tags.Add(
                new TagViewModel()
                {
                    Name = tagName
                });

            _window.AddTag(_window.TagText);
            _window.TagText = "";
        }

        private void TagIsSelected(object sender, EventArgs e)
        {
            var tagName = _window.SelectedTag;
            if (tagName != null)
            {
                _article.Tags.Remove(_article.Tags.Find(a => a.Name.Equals(tagName)));
                _window.RemoveTag(tagName);
            }
        }

        private void AuthorIsSelected(object sender, EventArgs e)
        {
            var login = _window.SelectedAuthor;
            if (login != null && !login.Equals(AccountPresenter.Get().Login))
            {
                if (!_window.Authors.Contains(login))
                {
                    _article.Authors.Remove(_article.Authors.Find(a => a.Login.Equals(login)));
                    _window.RemoveAuthor(login);
                }
            }
        }

        private void UpdateVisualData()
        {
            _window.Header = _article.Header;
            _window.Description = _article.ArticleText;
            var tagNames = _article.Tags.Select(t => t.Name).ToList();
            var categoryNames = _article.Categories.Select(t => t.Name).ToList();
            var authorNames = _article.Authors.Select(t => t.Name).ToList();
            _window.TagList = tagNames;
            _window.SelectedCategories = categoryNames;
            _window.Authors = authorNames;
        }

        private void DeleteLink_Click(object sender, EventArgs e)
        {
            if (_article.Id != -1)
            {
                _articleService.DeleteArticle(_article.Id);
                _window.Close();
                new MainPresenter(new MainWindow());
                
            }
            else
            {
                MessageBox.Show("No such article!");
            }

        }
        public string CreateArticle(ArticleViewModel article)
        {
            try
            {
                var articleDTO = new ArticleDTO();
                articleDTO.Text = article.ArticleText;
                articleDTO.Header = article.Header;
                articleDTO.AuthorDTOs = article.Authors.Select(a => new UserDTO { Id = a.Id });
                articleDTO.CategoryDTOs = article.Categories.Select(a => new ArticleCategoryDTO() { Name = a.Name });
                articleDTO.TagDTOs = article.Tags.Select(a => new ArticleTagDTO() { Name = a.Name });
                _publishService.PublishArticle(articleDTO);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;
        }

        public void GetArticleId(ref ArticleViewModel article)
        {
            try
            {
                article.Id = _publishService.GetArticleIdByHeader(article.Header);
            }
            catch
            {
                article.Id = -1;
            }
        }

        public string UpdateArticle(ArticleViewModel article)
        {
            try
            {
                var articleDTO = new ArticleDTO();
                articleDTO.Id = article.Id;
                articleDTO.Text = article.ArticleText;
                articleDTO.Header = article.Header;
                articleDTO.AuthorDTOs = article.Authors.Select(a => new UserDTO { Id = a.Id });
                articleDTO.CategoryDTOs = article.Categories.Select(a => new ArticleCategoryDTO() { Name = a.Name });
                articleDTO.TagDTOs = article.Tags.Select(a => new ArticleTagDTO() { Name = a.Name });
                _publishService.UpdateArticle(articleDTO);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;
        }
    }
}
