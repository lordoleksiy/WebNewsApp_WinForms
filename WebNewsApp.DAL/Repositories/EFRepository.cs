using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.DAL.Interfaces;

namespace WebNewsApp.DAL.Repositories
{
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

        public void Delete(TEntity item)
        {
            if (_entities.Find(item) != null)
            {
                _entities.Remove(item);
            }
        }

        public TEntity Get(int id)
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
    }
}
