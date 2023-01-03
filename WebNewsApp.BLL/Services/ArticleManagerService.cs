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

        public IEnumerable<ArticleDTO> FindByHeader(string header)
        {
            var articlesDal = UnitOfWork.ArticleRepository.Find(x => x.Header.Equals(header));
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
            });
            return articles;
        }

        public IEnumerable<ArticleDTO> FindByUserId(int userId)
        {
            var articlesDal = UnitOfWork.UserRepository.GetById(userId).Articles;
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
            });
            return articles;
        }

        public IEnumerable<ArticleDTO> GetAll()
        {
            var articlesDal = UnitOfWork.ArticleRepository.GetAll().ToList();
            if (articlesDal.Count() == 0) throw new ValidationException("No articles found");
            
            return MapArticles(articlesDal);
        }

        public IEnumerable<ArticleDTO> FindByCategory()
        {
            return null;
        }

        public IEnumerable<ArticleDTO> FindByUserLogin(string login)
        {
            var user = UnitOfWork.UserRepository.Find(a => a.Login.Equals(login)).FirstOrDefault();
            if (user == null) throw new ValidationException("No such user");
            return MapArticles(user.Articles);
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

        public ArticleCategoryDTO GetCategoryById(int id)
        {
            var categoryDal = UnitOfWork.CategoryRepository.GetById(id);
            var category = new ArticleCategoryDTO()
            {
                Id = categoryDal.Id,
                Name = categoryDal.Name,
                Description= categoryDal.Description
            };
            return category;
        }

        public IEnumerable<ArticleCategoryDTO> GetCategories()
        {
            var categoriesDal = UnitOfWork.CategoryRepository.GetAll();
            var categories = categoriesDal.Select(a => new ArticleCategoryDTO()
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description
            });
            return categories;
        }


        public ArticleDTO LoadArticleById(int id)
        {
            var article = UnitOfWork.ArticleRepository.GetById(id);
            if (article == null) throw new ValidationException("No article found");
            return ArticleDalMapper.Map<ArticleDTO>(article);
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
