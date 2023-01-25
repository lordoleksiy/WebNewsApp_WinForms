using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebNewsApp.DAL.Interfaces
{
    //public interface ArticleRepository : IRepository<int,Article>
    //Extend methods
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
