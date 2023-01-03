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
            var users = _articleService.GetAll();
            return convertArticles(users);
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
                //Authors = new List<UserViewModel>(article.AuthorDTOs.Select(a => new UserViewModel() { Id = a.Id, Login = a.Login})),
                //Tags = new List<TagViewModel>(article.TagDTOs.Select(a => new TagViewModel() { Id =  a.Id, Name = a.Name}))
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
            return "Article is created!";
        }
    }
}
