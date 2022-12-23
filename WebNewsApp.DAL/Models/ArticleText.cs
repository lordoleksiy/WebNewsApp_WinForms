using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNewsApp.DAL.Models
{
    public class ArticleText
    {
        public int ArticleTextId { get; set; }
        public string Text { get; set; }
        public virtual Article Article { get; set; }
    }
}
