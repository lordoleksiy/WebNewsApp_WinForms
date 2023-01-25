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
    public class PublishManagerService : AutoMapperService, IPublishManagerService
    {
        private readonly EFUnitOfWork UnitOfWork;
        public PublishManagerService(EFUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public void DeleteArticle(int id)
        {
            UnitOfWork.ArticleRepository.Delete(id);
            UnitOfWork.Save();
        }

        public void GetArticleByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public void PublishArticle(ArticleDTO article)  // return id
        {
            var articleDal = new Article()
            {
                Header = article.Header,
                PublishedTime = DateTime.Now,
                ArticleText = new ArticleText() { Text = article.Text },
                Authors = new List<User>(),
                Tags = new List<ArticleTag>(),
                Categories = new List<ArticleCategory>()
            };
            foreach (var tag in article.TagDTOs)
            {
                var tagDal = UnitOfWork.TagRepository.Find(t => t.Name.Equals(tag.Name)).FirstOrDefault();
                if (tagDal == null)
                {
                    articleDal.Tags.Add(new ArticleTag() { Name = tag.Name });
                }
                else
                {
                    articleDal.Tags.Add(tagDal);
                }
            }
            foreach (var category in article.CategoryDTOs)
            {
                var categoryDal = UnitOfWork.CategoryRepository.Find(a => a.Name.Equals(category.Name)).FirstOrDefault();
                articleDal.Categories.Add(categoryDal);
            }
            foreach (var user in article.AuthorDTOs)
            {
                var userDal = UnitOfWork.UserRepository.GetById(user.Id);
                articleDal.Authors.Add(userDal);
            }
            UnitOfWork.ArticleRepository.Create(articleDal);
            UnitOfWork.Save();
        }

        public int GetArticleIdByHeader(string header)
        {
            var userDal = UnitOfWork.ArticleRepository.Find(a => a.Header.Equals(header)).LastOrDefault();
            if (userDal == null) throw new ValidationException("No such user");
            return userDal.Id;
        }

        public void UpdateArticle(ArticleDTO article)
        {
            var articleDal = UnitOfWork.ArticleRepository.GetById(article.Id);
            if (articleDal == null) throw new ValidationException("No such article");
            articleDal.Header = article.Header;
            articleDal.ArticleText.Text = article.Text;
            articleDal.Tags.Clear();
            articleDal.Authors.Clear();
            articleDal.Tags.Clear();
            foreach (var tag in article.TagDTOs)
            {
                var tagDal = UnitOfWork.TagRepository.Find(t => t.Name.Equals(tag.Name)).FirstOrDefault();
                if (tagDal == null)
                {
                    articleDal.Tags.Add(new ArticleTag() { Name = tag.Name });
                }
                else
                {
                    articleDal.Tags.Add(tagDal);
                }
            }
            foreach (var category in article.CategoryDTOs)
            {
                var categoryDal = UnitOfWork.CategoryRepository.Find(a => a.Name.Equals(category.Name)).FirstOrDefault();
                articleDal.Categories.Add(categoryDal);
            }
            foreach (var user in article.AuthorDTOs)
            {
                var userDal = UnitOfWork.UserRepository.GetById(user.Id);
                articleDal.Authors.Add(userDal);
            }
            
            // update all links:

            foreach (var category in articleDal.Categories)
            {
                UnitOfWork.CategoryRepository.Update(category);  
            }

            foreach (var author in articleDal.Authors)
            {
                UnitOfWork.UserRepository.Update(author);
            }

            foreach (var tag in articleDal.Tags)
            {
                UnitOfWork.TagRepository.Update(tag);
            }

            UnitOfWork.ArticleRepository.Update(articleDal);
            UnitOfWork.Save();
        }
    }
}
