using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GrainTWdata.DB;

public partial class GrainTwContext : DbContext
{
    public GrainTwContext()
    {
    }

    public GrainTwContext(DbContextOptions<GrainTwContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblGrainReceipt> TblGrainReceipts { get; set; }
    public virtual DbSet<TblGrainReceiptMerged> TblGrainReceiptMerged { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=COMP3\\SQLEXPRESS;Database=GrainTW;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblGrainReceipt>(entity =>
        {
            entity.HasKey(d => d.SysId);
            entity.Property(e => e.CounterpartyName).HasMaxLength(500);
            entity.Property(e => e.CropYear)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Garbage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Infection).HasMaxLength(200);
            entity.Property(e => e.Price).HasColumnType("float");
            entity.Property(e => e.Process).HasMaxLength(200);
            entity.Property(e => e.Product).HasMaxLength(500);
            entity.Property(e => e.RecordDate).HasColumnType("datetime");
            entity.Property(e => e.SysId)
                .ValueGeneratedOnAdd()
                .HasColumnName("SysID");
            entity.Property(e => e.Wetness).HasColumnType("float");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
