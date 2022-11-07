using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.DAL.Interfaces;

namespace WebNewsApp.DAL.Repositories
{
    internal class TopicRepository: IRepository<ArticleTopic>
    {
        private readonly DataContext DB;
        public TopicRepository(DataContext dataContext)
        {
            DB = dataContext;
        }

        public void Create(ArticleTopic item)
        {
            DB.ArticleTopics.Add(item);
        }

        public void Delete(ArticleTopic item)
        {
            if (DB.ArticleTopics.Find(item) != null)
            {
                DB.ArticleTopics.Remove(item);
            }
        }

        public ArticleTopic Get(int id)
        {
            return DB.ArticleTopics.Find(id);
        }

        public IEnumerable<ArticleTopic> GetAll()
        {
            return DB.ArticleTopics;
        }

        public void Update(ArticleTopic item)
        {
            DB.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
