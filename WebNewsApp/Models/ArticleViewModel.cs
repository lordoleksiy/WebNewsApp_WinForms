using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNewsApp.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedTime { get; set; }
        public string Topic { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

    }
}
