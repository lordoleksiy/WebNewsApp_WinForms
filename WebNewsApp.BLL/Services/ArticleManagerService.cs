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

        public IEnumerable<ArticleDTO> GetAll()
        {
            var articlesDal = UnitOfWork.ArticleRepository.GetAll().ToList();
            if (articlesDal.Count() == 0) throw new ValidationException("No articles found");

            return ArticleMapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(articlesDal);
        }

        public IEnumerable<ArticleDTO> FindByHeader(string header)
        {
            var articlesDal = UnitOfWork.ArticleRepository.Find(x => x.Header.Equals(header));
            return ArticleMapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(articlesDal);
        }

        public IEnumerable<ArticleDTO> FindByUserLogin(string login)
        {
            var user = UnitOfWork.UserRepository.Find(a => a.Login.Equals(login)).FirstOrDefault();
            if (user == null) throw new ValidationException("No such user");
            return ArticleMapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(user.Articles);
        }
        public IEnumerable<ArticleDTO> FindByCategoryName(string categoryName)
        {
            var category = UnitOfWork.CategoryRepository.Find(a => a.Name.Equals(categoryName)).FirstOrDefault();
            if (category == null) throw new ValidationException("No such category name");
            return ArticleMapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(category.Articles);
        }
        public IEnumerable<ArticleDTO> FindByTagName(string tagName)
        {
            var tag = UnitOfWork.TagRepository.Find(a => a.Name.Equals(tagName)).FirstOrDefault();
            if (tag == null) throw new ValidationException("No such tag name");
            return ArticleMapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(tag.Articles);
        }
        public IEnumerable<ArticleDTO> FindByTime(DateTime start, DateTime end)
        {
            var articles = UnitOfWork.ArticleRepository.Find(a => a.PublishedTime > start && a.PublishedTime < end);
            return ArticleMapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(articles);
        }
        public IEnumerable<ArticleCategoryDTO> GetAllCategories()
        {
            var categoriesDal = UnitOfWork.CategoryRepository.GetAll();
            return CategoryMapper.Map<IEnumerable<ArticleCategory>, IEnumerable<ArticleCategoryDTO>>(categoriesDal);
        }

        public string GetTextByArticleId(int id)
        {
            var article = UnitOfWork.ArticleRepository.GetById(id);
            return article.ArticleText.Text;
        }

        public void DeleteArticle(int id)
        {
            UnitOfWork.ArticleRepository.Delete(id);
            UnitOfWork.Save();
        }
    }
}
