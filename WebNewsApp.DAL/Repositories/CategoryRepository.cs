using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.DAL.Interfaces;

namespace WebNewsApp.DAL.Repositories
{
    internal class CategoryRepository : IRepository<ArticleCategory>
    {
        private readonly DataContext DB;
        public CategoryRepository(DataContext dataContext)
        {
            DB = dataContext;
        }
        void IRepository<ArticleCategory>.Create(ArticleCategory item)
        {
            DB.ArticleCategories.Add(item);
        }

        void IRepository<ArticleCategory>.Delete(ArticleCategory item)
        {
            if (DB.ArticleCategories.Find(item) != null)
            {
                DB.ArticleCategories.Remove(item);
            }
        }

        ArticleCategory IRepository<ArticleCategory>.Get(int id)
        {
            return DB.ArticleCategories.Find(id);
        }

        IEnumerable<ArticleCategory> IRepository<ArticleCategory>.GetAll()
        {
            return DB.ArticleCategories;
        }

        void IRepository<ArticleCategory>.Update(ArticleCategory item)
        {
            DB.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
