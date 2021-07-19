using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using XuDb;

namespace XuModel.Db
{
    public partial class XuDbContext : DbContext
    {
        public XuDbContext()
        {

        }

        public XuDbContext(DbContextOptions<XuDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.UseName)
                    .IsRequired()
                    .HasColumnName("UseName")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Account)
                    .HasColumnName("Account")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e.PassWord)
                    .HasColumnName("PassWord")
                    .HasColumnType("varchar(16)");

                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CreateTime)
                    .IsRequired()
                    .HasColumnName("CreateTime")
                    .HasColumnType("DateTime");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("State")
                    .HasColumnType("int");
            });
        }
    }
}
