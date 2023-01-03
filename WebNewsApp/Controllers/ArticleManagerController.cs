using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.BLL.DTO;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.Models;

namespace WebNewsApp.Controllers
{
    public class ArticleManagerController
    {
        private IArticleManagerService _articleService;
        private IPublishManagerService _publishService;
        public ArticleManagerController(IArticleManagerService articleService, IPublishManagerService publishService)
        {
            _articleService = articleService;
            _publishService = publishService;
        }

        public IEnumerable<ArticleViewModel> GetArticles()
        {
            var articles = _articleService.GetAll();
            return convertArticles(articles);
        }

        public string LoadTextByArticleId(int id)
        {
            return _articleService.GetTextByArticleId(id);
        }
        public IEnumerable<CategoryViewModel> LoadCategories()
        {
            var categoriesDTO = _articleService.GetAllCategories();
            var categories = categoriesDTO.Select(a => new CategoryViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description
            });
            return categories;
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

        public void GetArticleId( ref ArticleViewModel article)
        {
            try
            {
                article.Id = _publishService.GetArticleIdByHeader(article.Header);
            }
            catch(Exception ex)
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

        public IEnumerable<ArticleViewModel> GetArticlesByAuthor(string login)
        {
            try
            {
                return convertArticles(_articleService.FindByUserLogin(login));
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ArticleViewModel> GetArticlesByCategory(string categoryName)
        {
            try
            {
                return convertArticles(_articleService.FindByCategoryName(categoryName));
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ArticleViewModel> GetArticlesByTag(string tagName)
        {
            try
            {
                return convertArticles(_articleService.FindByTagName(tagName));
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<ArticleViewModel> GetArticlesByHeader(string header)
        {
            return convertArticles(_articleService.FindByHeader(header));
        }

        public IEnumerable<ArticleViewModel> GetArticlesByTime(string date1, string date2)
        {
            var start = DateTime.Parse(date1);
            var end = DateTime.Parse(date2);
            return convertArticles(_articleService.FindByTime(start, end));  
        }
    }
}
