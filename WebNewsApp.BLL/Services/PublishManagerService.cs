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
    public class PublishManagerService : IPublishManagerService
    {
        private readonly EFUnitOfWork UnitOfWork;
        public PublishManagerService(EFUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public void DeleteArticle(int id)
        {
            throw new NotImplementedException();
        }

        public void GetArticleByUserId(int id)
        {
            throw new NotImplementedException();
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
            foreach (var tagName in article.TagDTOs)
            {
                var tagDal = UnitOfWork.TagRepository.Find(t => t.Name.Equals(tagName)).FirstOrDefault();
                if (tagDal == null)
                {
                    UnitOfWork.TagRepository.Create(new ArticleTag()
                    {
                        Name = tagName,
                        Articles = new List<Article>() { articleDal }
                    });
                }
                tagDal.Articles.Add(articleDal);
                UnitOfWork.TagRepository.Update(tagDal);
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
