﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using rebulanyum.CatalogApp.Data;

namespace rebulanyum.CatalogApp.Business
{
    /// <summary>
    /// The class that represents store for entities.
    /// </summary>
    public partial class CatalogAppContext : DbContext
    {
        public CatalogAppContext()
        {
        }

        public CatalogAppContext(DbContextOptions<CatalogAppContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// The Products in the store.
        /// </summary>
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Photo)
                    .HasColumnType("varbinary")
                    .HasMaxLength(8000);

                entity.Property(e => e.Price).HasColumnType("money");
            });
        }
    }
}
