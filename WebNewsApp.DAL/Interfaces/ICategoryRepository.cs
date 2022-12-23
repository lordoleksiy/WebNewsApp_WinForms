using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.DAL.Models;

namespace WebNewsApp.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<ArticleCategory> GetAll();
        ArticleCategory GetById(int id);
        ArticleCategory GetByName(string name);
    }
}
