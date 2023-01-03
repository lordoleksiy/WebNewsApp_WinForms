using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.BLL.DTO;

namespace WebNewsApp.BLL.Interfaces
{
    public interface IPublishManagerService
    {
        void PublishArticle(ArticleDTO article);
        void UpdateArticle(ArticleDTO article);
        void DeleteArticle(int id);
        void GetArticleByUserId(int id);
    }
}
