using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.DAL.Interfaces;

namespace WebNewsApp.DAL.Repositories
{
    internal class UserRepostory: IRepository<User>
    {
        private readonly DataContext DB;
        public UserRepostory(DataContext dataContext)
        {
            DB = dataContext;
        }

        void IRepository<User>.Create(User item)
        {
            DB.Users.Add(item);
        }

        void IRepository<User>.Delete(User item)
        {
            if (DB.Users.Find(item) != null)
            {
                DB.Users.Remove(item);
            }
        }

        User IRepository<User>.Get(int id)
        {
            return DB.Users.Find(id);
        }

        IEnumerable<User> IRepository<User>.GetAll()
        {
            return DB.Users;
        }

        void IRepository<User>.Update(User item)
        {
            DB.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
