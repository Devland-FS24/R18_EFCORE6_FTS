using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ReactNC6FTS_Full.Models
{
    public partial class MoviesDBContext : DbContext
    {
        public MoviesDBContext()
        {
        }

        public MoviesDBContext(DbContextOptions<MoviesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cast> Casts { get; set; } = null!;
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<MovieCast> MovieCasts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-LKBBPMQJ\\SQLEXPRESS; DataBase=MoviesDB;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cast>(entity =>
            {
                entity.ToTable("Cast");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Imdbrate).HasColumnName("IMDBRate");

                entity.Property(e => e.KnownBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LatestAppearance)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerContact)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Genre).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<MovieCast>(entity =>
            {
                entity.ToTable("MovieCast");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Cast)
                    .WithMany(p => p.MovieCasts)
                    .HasForeignKey(d => d.CastId)
                    .HasConstraintName("FK_MovieCast_Cast");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieCasts)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_MovieCast_Movie");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
