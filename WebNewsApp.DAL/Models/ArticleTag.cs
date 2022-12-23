using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNewsApp.DAL.Models
{
    public class ArticleTag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
