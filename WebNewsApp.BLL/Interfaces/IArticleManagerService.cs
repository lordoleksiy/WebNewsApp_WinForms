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
        IEnumerable<ArticleDTO> FindByCategoryName(string categoryName);
        IEnumerable<ArticleDTO> FindByTagName(string tagName);
        IEnumerable<ArticleDTO> FindByTime(DateTime start, DateTime end);
        IEnumerable<ArticleDTO> FindByUserLogin(string login);
        IEnumerable<ArticleDTO> FindByHeader(string header);
        IEnumerable<ArticleCategoryDTO> GetCategoriesByArticleId(int id);
        IEnumerable<ArticleTagDTO> GetTagsByArticleId(int id);
        IEnumerable<UserDTO> GetAuthorsByArticleId(int id);
        IEnumerable<ArticleCategoryDTO> GetAllCategories();
        string GetTextByArticleId(int id);
    }
}
