using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNewsApp.DAL.Models;

namespace WebNewsApp.DAL
{
    class DbInitializer: CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var articleCategories = new List<ArticleCategory>()
            {
                new ArticleCategory()
                {
                    Name = "sport",
                    Description = "All about sport events, people and results."
                },
                new ArticleCategory()
                {
                    Name = "celebreties",
                    Description = "Jossip, sensations and just news about celebreties."
                },
                new ArticleCategory()
                {
                    Name = "culture",
                    Description = "Museums, exhipitions and more..."
                },
                new ArticleCategory()
                {
                    Name = "music",
                    Description = "All about musicans and musical events."
                },
                new ArticleCategory(){
                    Name = "nature",
                    Description = "Articles about fantastic places mady by nature."
                }
            };

            foreach (var article in articleCategories)
            {
                context.ArticleCategories.Add(article);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
