using Microsoft.EntityFrameworkCore;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
