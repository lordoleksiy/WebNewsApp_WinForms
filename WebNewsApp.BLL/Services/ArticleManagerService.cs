using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.BLL.DTO;
using WebNewsApp.BLL.Infrastructure;
using WebNewsApp.BLL.Interfaces;
using WebNewsApp.DAL.Models;
using WebNewsApp.DAL.Repositories;

namespace WebNewsApp.BLL.Services
{
    public class ArticleManagerService : AutoMapperService, IArticleManagerService
    {
        private readonly EFUnitOfWork UnitOfWork;
        public ArticleManagerService(EFUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        //public ArticleDTO Find(int id)
        //{
        //    var articleDal = UnitOfWork.ArticleRepository.GetById(id);
        //    ArticleDTO article = new ArticleDTO
        //    {
        //        Id = articleDal.Id,
        //        Header = articleDal.Header,
        //        PublishedTime = articleDal.PublishedTime,
        //        Text = articleDal.ArticleText.Text,
        //        AuthorDTOs = articleDal.Authors.Select(a => new UserDTO
        //        {
        //            Login = a.Login,
        //            Name = a.Name,
        //            Surname = a.Surname,
        //        }),
        //        TagDTOs = articleDal.Tags.Select(t => t.Name)
        //    };
        //    return article;
        //}

        public IEnumerable<ArticleDTO> FindByCategoryId(int categoryId)
        {
            var articlesDal = UnitOfWork.CategoryRepository.GetById(categoryId).Articles;
            var articles = articlesDal.Select(a => new ArticleDTO
            {
                Id = a.Id,
                Header = a.Header,
                PublishedTime = a.PublishedTime,
                AuthorDTOs = a.Authors.Select(u => new UserDTO
                {
                    Login = u.Login,
                    Name = u.Name,
                    Surname = u.Surname,
                }),
                //TagDTOs = a.Tags.Select(t => t.Name)
            }) ;
            return articles;
        }


        public IEnumerable<ArticleDTO> GetAll()
        {
            var articlesDal = UnitOfWork.ArticleRepository.GetAll().ToList();
            if (articlesDal.Count() == 0) throw new ValidationException("No articles found");
            
            return MapArticles(articlesDal);
        }

        public IEnumerable<ArticleDTO> FindByHeader(string header)
        {
            var articlesDal = UnitOfWork.ArticleRepository.Find(x => x.Header.Equals(header));
            return MapArticles(articlesDal); 
        }

        public IEnumerable<ArticleDTO> FindByUserLogin(string login)
        {
            var user = UnitOfWork.UserRepository.Find(a => a.Login.Equals(login)).FirstOrDefault();
            if (user == null) throw new ValidationException("No such user");
            return MapArticles(user.Articles);
        }
        public IEnumerable<ArticleDTO> FindByCategoryName(string categoryName)
        {
            var category = UnitOfWork.CategoryRepository.GetByName(categoryName);
            if (category == null) throw new ValidationException("No such category name");
            return MapArticles(category.Articles);
        }
        public IEnumerable<ArticleDTO> FindByTagName(string tagName)
        {
            var tag = UnitOfWork.TagRepository.Find(a => a.Name.Equals(tagName)).FirstOrDefault();
            if (tag == null) throw new ValidationException("No such tag name");
            return MapArticles(tag.Articles);
        }
        public IEnumerable<ArticleDTO> FindByTime(DateTime start, DateTime end)
        {
            var articles = UnitOfWork.ArticleRepository.Find(a => a.PublishedTime > start && a.PublishedTime < end);
            return MapArticles(articles);
        }
        public IEnumerable<ArticleCategoryDTO> GetAllCategories()
        {
            var categoriesDal = UnitOfWork.CategoryRepository.GetAll();
            return categoriesDal.Select(a => new ArticleCategoryDTO
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description
            });
        }

        public string GetTextByArticleId(int id)
        {
            var article = UnitOfWork.ArticleRepository.GetById(id);
            return article.ArticleText.Text;
        }
        public IEnumerable<UserDTO> GetAuthorsByArticleId(int id)
        {
            var article = UnitOfWork.ArticleRepository.GetById(id);
            if (article == null) throw new ValidationException("No article found");
            return  UserMapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(article.Authors);
        }

        public IEnumerable<ArticleCategoryDTO> GetCategoriesByArticleId(int id)
        {
            var article = UnitOfWork.ArticleRepository.GetById(id);
            if (article == null) throw new ValidationException("No article with such id");
            return article.Categories.Select(a => new ArticleCategoryDTO()
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description
            }).ToList();
        }

        public IEnumerable<ArticleTagDTO> GetTagsByArticleId(int id)
        {
            var article = UnitOfWork.ArticleRepository.GetById(id);
            if (article == null) throw new ValidationException("No article with such id");
            return article.Tags.Select(a => new ArticleTagDTO()
            {
                Id = a.Id,
                Name = a.Name,
            }).ToList();
        }

        private IEnumerable<ArticleDTO> MapArticles(IEnumerable<Article> articlesDal)
        {
            return articlesDal.Select(a => new ArticleDTO
            {
                Id = a.Id,
                Header = a.Header,
                PublishedTime = a.PublishedTime,
                CategoryDTOs = GetCategoriesByArticleId(a.Id),
                TagDTOs = GetTagsByArticleId(a.Id),
                AuthorDTOs = GetAuthorsByArticleId(a.Id)
            });
        }
    }
}
