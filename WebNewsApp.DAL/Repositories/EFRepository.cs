using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.DAL.Interfaces;

namespace WebNewsApp.DAL.Repositories
{
    //class EFRepository<TKey,TEntity> : IRepository<TKey, TEntity> where TEntity<TKey>: class
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext Db;
        private readonly DbSet<TEntity> _entities;

        public EFRepository(DataContext dataContext)
        {
            Db = dataContext;
            _entities = Db.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            _entities.Add(item);
        }

        public void Delete(int id)
        {
            TEntity item = _entities.Find(id);
            if (item != null)
            {
                _entities.Remove(item);
            }
        }

        public TEntity GetById(int id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }

        public void Update(TEntity item)
        {
            Db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return _entities.Where(expression).ToList();
        }

        public int GetCount()
        {
            return _entities.Count();
        }
    }
}
