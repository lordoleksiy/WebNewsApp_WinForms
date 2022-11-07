using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.DAL.Interfaces;

namespace WebNewsApp.DAL.Repositories
{
    internal class ArticleRepository : IRepository<Article>
    {
        private readonly DataContext DB;
        public ArticleRepository(DataContext dataContext)
        {
            DB = dataContext;
        }
        void IRepository<Article>.Create(Article item)
        {
            DB.Articles.Add(item);
        }

        void IRepository<Article>.Delete(Article item)
        {
            if (DB.Articles.Find(item) != null)
            {
                DB.Articles.Remove(item);
            }
        }

        Article IRepository<Article>.Get(int id)
        {
            return DB.Articles.Find(id);
        }

        IEnumerable<Article> IRepository<Article>.GetAll()
        {
            return DB.Articles;
        }

        void IRepository<Article>.Update(Article item)
        {
            DB.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
