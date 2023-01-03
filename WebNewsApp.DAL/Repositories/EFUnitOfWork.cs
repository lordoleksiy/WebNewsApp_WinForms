using System;
using WebNewsApp.DAL.Models;
using WebNewsApp.DAL.Interfaces;

namespace WebNewsApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private bool disposedValue;
        private DataContext Db;
        private EFRepository<Article> articleRepository;
        private EFRepository<User> userRepository;
        private CategoryRepository categoryRepository;
        private EFRepository<ArticleTag> articleTagsRepository;

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
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new CategoryRepository(Db);
                }
                return categoryRepository;
            }
        }


        public IRepository<ArticleTag> TagRepository
        {
            get
            {
                if (articleTagsRepository == null)
                {
                    articleTagsRepository = new EFRepository<ArticleTag> (Db);
                }
                return articleTagsRepository;
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
