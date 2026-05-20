using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using YYMDoNet.DataAccess;

namespace YYMDotNetTraining.EFCore.DataAccess
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public virtual DbSet<TblStudent> TblStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=.;Database=YYMDotNetTraining.EFCore;User ID=sa;Password=sasa@123;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId);
                entity.ToTable("Tbl_Student");

                entity.Property(e => e.Address).HasMaxLength(250).IsUnicode(false);
                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
                entity.Property(e => e.FatherName).HasMaxLength(50);
                entity.Property(e => e.Gender).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.MobileNo).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.StudentName).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.StudentNo).HasMaxLength(10).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
