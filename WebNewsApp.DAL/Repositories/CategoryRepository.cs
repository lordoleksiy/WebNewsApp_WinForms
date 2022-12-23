using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.DAL.Interfaces;
using WebNewsApp.DAL.Models;

namespace WebNewsApp.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories;
        }

        public ArticleCategory GetById(int id)
        {
            return _context.ArticleCategories.Find(id);
        }

        public ArticleCategory GetByName(string name)
        {
            return _context.ArticleCategories.Where(c => c.Name.Equals(name)).FirstOrDefault();
        }
    }
}
