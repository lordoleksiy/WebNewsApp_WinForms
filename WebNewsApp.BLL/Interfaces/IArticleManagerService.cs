using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.BLL.DTO;

namespace WebNewsApp.BLL.Interfaces
{
    public interface IArticleManagerService
    {
        IEnumerable<ArticleDTO> GetAll();
        IEnumerable<ArticleDTO> FindByCategoryId(int id);
        IEnumerable<ArticleDTO> FindByUserId(int id);
        IEnumerable<ArticleDTO> FindByHeader(string header);
        ArticleCategoryDTO GetCategoryById(int id);
        IEnumerable<ArticleCategoryDTO> GetAllCategories();
    }
}
