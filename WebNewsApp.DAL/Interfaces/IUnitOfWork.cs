using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNewsApp.DAL.Interfaces
{
    internal interface IUnitOfWork: IDisposable
    {
        IRepository<Article> ArticleRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<ArticleCategory> CategoryRepository { get; }
        IRepository<ArticleTopic> TopicRepository { get; }
        void Save();

    }
}
