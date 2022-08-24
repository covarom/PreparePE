﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SE150557_NguyenHuuDoanRepo.BussinessObject.Models
{
    public partial class BankAccountTypeContext : DbContext
    {
        public BankAccountTypeContext()
        {
        }

        public BankAccountTypeContext(DbContextOptions<BankAccountTypeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__AccountT__516F0395B9DFCE78");

                entity.Property(e => e.TypeId)
                    .HasMaxLength(20)
                    .HasColumnName("TypeID");

                entity.Property(e => e.TypeDesc).HasMaxLength(250);

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__BankAcco__349DA586433F6330");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(20)
                    .HasColumnName("AccountID");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.BranchName).HasMaxLength(50);

                entity.Property(e => e.OpenDate).HasColumnType("date");

                entity.Property(e => e.TypeId)
                    .HasMaxLength(20)
                    .HasColumnName("TypeID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.BankAccounts)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__BankAccou__TypeI__286302EC");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasMaxLength(20)
                    .HasColumnName("UserID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(80);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
