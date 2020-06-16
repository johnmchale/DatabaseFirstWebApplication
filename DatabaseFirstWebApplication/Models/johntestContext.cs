using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatabaseFirstWebApplication.Models
{

    // n.b. the scafoolding process chose the name 'johntestContext' nbased on the database name which is called 'johntest' 
    public partial class johntestContext : DbContext
    {
        public johntestContext()
        {
        }

        public johntestContext(DbContextOptions<johntestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<Test2> Test2 { get; set; }
        public virtual DbSet<Test3> Test3 { get; set; }
        public virtual DbSet<Test4> Test4 { get; set; }
        public virtual DbSet<Test5> Test5 { get; set; }
        public virtual DbSet<Testb> Testb { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=johntest; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("test");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Test2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test2");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Test3>(entity =>
            {
                entity.ToTable("test3");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Test4>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test4");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Test5>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test5");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Testb>(entity =>
            {
                entity.ToTable("testb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
