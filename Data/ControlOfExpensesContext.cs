using System;
using System.Collections.Generic;
using ControlOfExpenses.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ControlOfExpenses.Data
{
    public partial class ControlOfExpensesContext : DbContext
    {
        public ControlOfExpensesContext()
        {
        }

        public ControlOfExpensesContext(DbContextOptions<ControlOfExpensesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Expense> Expenses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ControlOfExpenses; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Cost)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.User)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.DayCost)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.MonthCost)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.YearCost)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
