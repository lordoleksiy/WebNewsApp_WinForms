using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebNewsApp.DAL.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public DateTime PublishedTime { get; set; }
        public ICollection<User> Authors { get; set; } // eager
        public virtual ArticleText ArticleText { get; set; }
        public virtual ICollection<ArticleCategory> Categories { get; set; }
        public virtual ICollection<ArticleTag> Tags { get; set; }
    }
}
