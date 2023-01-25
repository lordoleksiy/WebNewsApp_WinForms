using System;
using WebNewsApp.DAL.Models;

namespace WebNewsApp.DAL.Interfaces
{
    internal interface IUnitOfWork: IDisposable
    {
        IRepository<Article> ArticleRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<ArticleCategory> CategoryRepository { get; }
        IRepository<ArticleTag> TagRepository { get; }
        void Save();

    }
}
