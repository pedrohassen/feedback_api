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
                entity.OwnsOne(u => u.Email, email =>
                {
                    email.Property(e => e.Endereco)
                        .HasColumnName("Email")
                        .IsRequired();
                });
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.OwnsOne(f => f.Texto, texto =>
                {
                    texto.Property(t => t.Texto)
                        .HasColumnName("Texto")
                        .IsRequired()
                        .HasMaxLength(500);
                });

                entity.HasOne(f => f.Usuario)
                    .WithMany(u => u.FeedBacksRecebidos)
                    .HasForeignKey(f => f.UsuarioId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
