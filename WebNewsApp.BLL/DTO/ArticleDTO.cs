using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNewsApp.BLL.DTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public DateTime PublishedTime { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public IEnumerable<UserDTO> AuthorDTOs { get; set; }
        public IEnumerable<ArticleTagDTO> TagDTOs { get; set; }
        public IEnumerable<ArticleCategoryDTO> CategoryDTOs { get; set; }
    }
}
