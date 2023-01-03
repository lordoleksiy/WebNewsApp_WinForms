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
        public string Header { get; set; }
        public DateTime PublishedTime { get; set; }
        public string ArticleText { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public List<UserViewModel> Authors { get; set; }
        public List<TagViewModel> Tags { get; set; }

    }
}
