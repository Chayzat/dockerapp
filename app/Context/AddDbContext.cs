using app.Models;
using Microsoft.EntityFrameworkCore;

namespace app.Context
{

    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
            .HasOne(e => e.Author)
            .WithMany()
            .HasForeignKey(e => e.AuthorId);
            // .HasPrincipalKey(e => e.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}