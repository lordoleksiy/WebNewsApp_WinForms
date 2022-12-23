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
    public class ArticleManagerService : IArticleManagerService
    {
        private readonly EFUnitOfWork UnitOfWork;
        public ArticleManagerService(EFUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void DeleteArticle(int id)
        {
            UnitOfWork.ArticleRepository.Delete(id);
            UnitOfWork.Save();
        }

        public ArticleDTO Find(int id)
        {
            var articleDal = UnitOfWork.ArticleRepository.GetById(id);
            ArticleDTO article = new ArticleDTO
            {
                Id = articleDal.Id,
                Header = articleDal.Header,
                PublishedTime = articleDal.PublishedTime,
                Text = articleDal.ArticleText.Text,
                AuthorDTOs = articleDal.Authors.Select(a => new UserDTO
                {
                    Login = a.Login,
                    Name = a.Name,
                    Surname = a.Surname,
                }),
                TagDTOs = articleDal.Tags.Select(t => t.Name)
            };
            return article;
        }

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
                TagDTOs = a.Tags.Select(t => t.Name)
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
                TagDTOs = a.Tags.Select(t => t.Name)
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
                TagDTOs = a.Tags.Select(t => t.Name)
            });
            return articles;
        }

        public IEnumerable<ArticleDTO> GetAll()
        {
            var articlesDal = UnitOfWork.ArticleRepository.GetAll();
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
                TagDTOs = a.Tags.Select(t => t.Name)
            });
            return articles;
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

        public void PublishArticle(ArticleDTO article, int userId)
        {
            var user = UnitOfWork.UserRepository.GetById(userId);
            if (user == null) throw new ValidationException("No user with such id!");
            var articleDal = new Article()
            {
                Header = article.Header,
                PublishedTime = DateTime.Now,
                ArticleText = new ArticleText() { Text = article.Text },
                Authors = new List<User>() { user },
            };
            UnitOfWork.ArticleRepository.Create(articleDal);
            foreach(var tagName in article.TagDTOs)
            {
                var tagDal = UnitOfWork.TagRepository.Find(t => t.Name.Equals(tagName)).First();
                if (tagDal == null)
                {
                    UnitOfWork.TagRepository.Create(new ArticleTag()
                    {
                        Name = tagName,
                        Articles = new List<Article>() { articleDal }
                    });
                }
                else
                {
                    tagDal.Articles.Add(articleDal);
                    UnitOfWork.TagRepository.Update(tagDal);
                }
            }
            UnitOfWork.Save();
        }

        public void UpdateArticle(ArticleDTO article)
        {
            var articleDal = UnitOfWork.ArticleRepository.GetById(article.Id);
            articleDal.Header = article.Header;
            articleDal.ArticleText.Text = article.Text;
            UnitOfWork.ArticleRepository.Update(articleDal);
            UnitOfWork.Save();
            // недоделано!!!!!!! и роставь везде екскпшены
        }
    }
}
