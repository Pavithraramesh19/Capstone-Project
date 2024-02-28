﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlogWebapi.Models
{
    public partial class BlogWebapiDataContext : DbContext
    {
        public BlogWebapiDataContext()
        {
        }

        public BlogWebapiDataContext(DbContextOptions<BlogWebapiDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminInfo> AdminInfos { get; set; } = null!;
        public virtual DbSet<BlogInfo> BlogInfos { get; set; } = null!;
        public virtual DbSet<EmpInfo> EmpInfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-E39FGJN;Database=BlogWebapi.Data;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminInfo>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("AdminInfo");
            });

            modelBuilder.Entity<BlogInfo>(entity =>
            {
                entity.HasKey(e => e.BlogId);

                entity.ToTable("BlogInfo");

                entity.HasIndex(e => e.Email, "IX_BlogInfo_Email");

                entity.HasOne(d => d.EmailNavigation)
                    .WithMany(p => p.BlogInfos)
                    .HasForeignKey(d => d.Email);
            });

            modelBuilder.Entity<EmpInfo>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("EmpInfo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
