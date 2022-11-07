using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Article
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime PublishedTime { get; set; }
    public int AuthorId { get; set; }
    public User Author { get; set; }
    public int ArticleTopicId { get; set; }
    public ArticleTopic Topic { get; set; }
    public int ArticleCategoryId { get; set; }
    public ArticleCategory Category { get; set; }
}
