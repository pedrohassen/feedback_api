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
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            //modelBuilder.Entity<Feedback>(entity =>
            //{
            //    entity.Property(f => f.Texto)
            //        .IsRequired()
            //        .HasMaxLength(500);

            //    entity.HasOne(f => f.Usuario)
            //        .WithMany(u => u.FeedbacksRecebidos)
            //        .HasForeignKey(f => f.UsuarioId)
            //        .OnDelete(DeleteBehavior.Cascade);
            //});
        }
    }
}
