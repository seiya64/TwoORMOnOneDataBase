using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFproject.Entities
{
    public partial class twoormonedbContext : DbContext
    {
        public twoormonedbContext()
        {
        }

        public twoormonedbContext(DbContextOptions<twoormonedbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MyObject> MyObject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;database=twoormonedb;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyObject>(entity =>
            {
                entity.HasIndex(e => e.Version)
                    .HasName("UQ__MyObject__0F5401346E9665EA")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Version)
                    .IsRequired()
                    .IsRowVersion();
            });
        }
    }
}
