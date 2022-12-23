using WebNewsApp.DAL.Models;
using System.Data.Entity;

namespace WebNewsApp.DAL
{
    public class DataContext: DbContext
    {
        public DataContext()
            : base("DbConnection") {}

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<ArticleText> ArticleTexts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("UserId");
            modelBuilder.Entity<User>().Property(u => u.Description).HasColumnName("UserDescription");

            modelBuilder.Entity<Article>().Property(a => a.Id).HasColumnName("ArticleId");
            modelBuilder.Entity<Article>().Property(a => a.Header).IsRequired();

            modelBuilder.Entity<ArticleCategory>().Property(ac => ac.Id).HasColumnName("ArticleCategoryId");
            modelBuilder.Entity<ArticleCategory>().Property(ac => ac.Name).HasColumnName("ArticleCategoryName");
            modelBuilder.Entity<ArticleCategory>().Property(ac => ac.Description).HasColumnName("ArticleCategoryDescription");
                

            modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();
            modelBuilder.Entity<User>().Property(u => u.Login).IsRequired().HasColumnType("VARCHAR").HasMaxLength(20);
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();

            modelBuilder.Entity<ArticleText>().Property(at => at.Text).IsRequired();
            modelBuilder.Entity<ArticleText>().HasKey(at => at.ArticleTextId);
            modelBuilder.Entity<Article>()
                .HasOptional(a => a.ArticleText)
                .WithRequired(at => at.Article)
                .WillCascadeOnDelete(true);


            modelBuilder.Entity<User>()
                .HasMany(u => u.Articles)
                .WithMany(a => a.Authors)
                .Map(cs =>
                {
                    cs.MapLeftKey("UserRefId");
                    cs.MapRightKey("ArticleRefId");
                    cs.ToTable("UsersArticles");
                });

            modelBuilder.Entity<ArticleCategory>().Property(ac => ac.Name).IsRequired();
            modelBuilder.Entity<Article>()
                .HasMany<ArticleCategory>(a => a.Categories)
                .WithMany(ac => ac.Articles)
                .Map(cs =>
                {
                    cs.MapLeftKey("ArticleRefId");
                    cs.MapRightKey("CategoryRefId");
                    cs.ToTable("ArticlesCategories");
                });

            modelBuilder.Entity<Article>()
                .HasMany<ArticleTag>(a => a.Tags)
                .WithMany(at => at.Articles)
                .Map(cs =>
                {
                    cs.MapLeftKey("ArticleRefId");
                    cs.MapRightKey("TagRefId");
                    cs.ToTable("ArticlesTags");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
