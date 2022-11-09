using Blog.Data.Mapings;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data 
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        => options.UseSqlServer("Server=DESKTOP-FPLV92N;Database=Blogs;Trusted_Connection=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }

    
}