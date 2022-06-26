using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFDBFirst.Data.Models
{
    public partial class DBFirstContext : DbContext
    {
        public DBFirstContext()
        {
        }

        public DBFirstContext(DbContextOptions<DBFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Train> Trains { get; set; } = null!;
        public virtual DbSet<TrainWorkingDay> TrainWorkingDays { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2PKBUH0\\SQLEXPRESS;Initial Catalog=DBFirst;Integrated Security=True;");
#pragma warning restore CS1030 // #warning directive
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Train>(entity =>
            {
                entity.HasKey(e => e.TrainNo);

                entity.ToTable("Train");

                entity.HasIndex(e => e.TrainNo, "UX_Table_1")
                    .IsUnique();

                entity.Property(e => e.TrainNo).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FromStation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ToStation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrainName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TrainWorkingDay>(entity =>
            {
                entity.HasKey(e => e.TrainId);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Day)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrainNo).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.TrainNoNavigation)
                    .WithMany(p => p.TrainWorkingDays)
                    .HasForeignKey(d => d.TrainNo)
                    .HasConstraintName("FK_TrainWorkingDays_Train");
            });

                 OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        
    }
}
