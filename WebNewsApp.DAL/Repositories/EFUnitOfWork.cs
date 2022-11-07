using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.DAL.Interfaces;

namespace WebNewsApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private bool disposedValue;
        private DataContext Db;
        private EFRepository<Article> articleRepository;
        private EFRepository<User> userRepository;
        private EFRepository<ArticleCategory> categoryRepository;
        private EFRepository<ArticleTopic> topicRepository;

        public EFUnitOfWork()
        {
            Db = new DataContext();
        }
        public IRepository<Article> ArticleRepository
        {
            get
            {
                if (articleRepository == null)
                {
                    articleRepository = new EFRepository<Article>(Db);
                }
                return articleRepository;
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new EFRepository<User>(Db);
                }
                return userRepository;
            }
        }
        public IRepository<ArticleCategory> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new EFRepository<ArticleCategory>(Db);
                }
                return categoryRepository;
            }
        }

        public IRepository<ArticleTopic> TopicRepository
        {
            get
            {
                if (topicRepository == null)
                {
                    topicRepository = new EFRepository<ArticleTopic>(Db);
                }
                return topicRepository;
            }
        }

        public void Save()
        {
            Db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Db.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
