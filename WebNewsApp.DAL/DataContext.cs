using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebNewsApp.DAL
{
    public class DataContext: DbContext
    {
        public DataContext()
            : base("DbConnection") {}

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleTopic> ArticleTopics { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Article>()
            //    .HasRequired(a => a.Author)
            //    .WithMany(u => u.Articles)
            //    .HasForeignKey(a => a.AuthorId);
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("UserId");
            modelBuilder.Entity<User>().Property(u => u.Description).HasColumnName("UserDescription");
            modelBuilder.Entity<Article>().Property(a => a.Id).HasColumnName("ArticleId");
            modelBuilder.Entity<ArticleTopic>().Property(at => at.Id).HasColumnName("ArticleId");

            modelBuilder.Entity<ArticleCategory>().Property(ac => ac.Id).HasColumnName("ArticleCategoryId");
            modelBuilder.Entity<ArticleCategory>().Property(ac => ac.Name).HasColumnName("ArticleCategoryName");
            modelBuilder.Entity<ArticleCategory>().Property(ac => ac.Description).HasColumnName("ArticleCategoryDescription");


            modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();
            modelBuilder.Entity<User>().Property(u => u.Login).IsRequired().HasColumnType("VARCHAR").HasMaxLength(20);
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();

            modelBuilder.Entity<Article>().Property(a => a.Title).IsRequired();
            modelBuilder.Entity<Article>().HasRequired(a => a.Category);
            modelBuilder.Entity<Article>().HasRequired(a => a.Topic);

            modelBuilder.Entity<ArticleTopic>().Property(at => at.Text).IsRequired();
            modelBuilder.Entity<ArticleCategory>().Property(ac => ac.Name).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
