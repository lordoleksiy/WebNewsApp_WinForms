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

        public void PublishArticle(ArticleDTO article)
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
                var categoryDal = UnitOfWork.CategoryRepository.GetById(category.Id);
                articleDal.Categories.Add(categoryDal);
            }
            foreach (var user in articleDal.Authors)
            {
                var userDal = UnitOfWork.UserRepository.GetById(user.Id);
                articleDal.Authors.Add(userDal);
            }
            UnitOfWork.ArticleRepository.Create(articleDal);
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
