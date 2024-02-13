using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GlamGaideDBWebApplication.Models;

public partial class GlamGaideDbContext : DbContext
{
    public GlamGaideDbContext()
    {
    }

    public GlamGaideDbContext(DbContextOptions<GlamGaideDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BeatyBuddy> BeatyBuddies { get; set; }

    public virtual DbSet<Consultation> Consultations { get; set; }

    public virtual DbSet<ConsultationTip> ConsultationTips { get; set; }

    public virtual DbSet<CosmeticProduct> CosmeticProducts { get; set; }

    public virtual DbSet<ProductTip> ProductTips { get; set; }

    public virtual DbSet<SkinType> SkinTypes { get; set; }

    public virtual DbSet<Tip> Tips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VideoTutorial> VideoTutorials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= DESKTOP-1OPQI34\\SQL; Database=GlamGaideDB; Trusted_Connection=True; Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Ukrainian_CI_AS");

        modelBuilder.Entity<BeatyBuddy>(entity =>
        {
            entity.ToTable("BeatyBuddy");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Consultation>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.BeatyBuddyId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("BeatyBuddyID");
            entity.Property(e => e.Question).HasColumnType("text");
            entity.Property(e => e.Response).HasColumnType("text");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.BeatyBuddy).WithMany(p => p.Consultations)
                .HasForeignKey(d => d.BeatyBuddyId)
                .HasConstraintName("FK_Consultations_BeatyBuddy");

            entity.HasOne(d => d.User).WithMany(p => p.Consultations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Consultations_Users");
        });

        modelBuilder.Entity<ConsultationTip>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.ConsultationId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ConsultationID");
            entity.Property(e => e.TipId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("TipID");

            entity.HasOne(d => d.Consultation).WithMany(p => p.ConsultationTips)
                .HasForeignKey(d => d.ConsultationId)
                .HasConstraintName("FK_ConsultationsTips_Consultations");

            entity.HasOne(d => d.Tip).WithMany(p => p.ConsultationTips)
                .HasForeignKey(d => d.TipId)
                .HasConstraintName("FK_ConsultationsTips_Tips");
        });

        modelBuilder.Entity<CosmeticProduct>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Brand)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SkinTypeId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SkinTypeID");

            entity.HasOne(d => d.SkinType).WithMany(p => p.CosmeticProducts)
                .HasForeignKey(d => d.SkinTypeId)
                .HasConstraintName("FK_CosmeticProducts_SkinTypes");
        });

        modelBuilder.Entity<ProductTip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProductTips_");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ProductID");
            entity.Property(e => e.TipId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("TipID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductTips)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductTips_CosmeticProducts");

            entity.HasOne(d => d.Tip).WithMany(p => p.ProductTips)
                .HasForeignKey(d => d.TipId)
                .HasConstraintName("FK_ProductTips_Tips");
        });

        modelBuilder.Entity<SkinType>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Tip>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.TipType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Title)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.Bio).HasColumnType("text");
            entity.Property(e => e.Email)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SkinTypeId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SkinTypeID");

            entity.HasOne(d => d.SkinType).WithMany(p => p.Users)
                .HasForeignKey(d => d.SkinTypeId)
                .HasConstraintName("FK_Users_SkinTypes");
        });

        modelBuilder.Entity<VideoTutorial>(entity =>
        {
            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ID");
            entity.Property(e => e.AuthorId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("AuthorID");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.VideoLink)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Author).WithMany(p => p.VideoTutorials)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_VideoTutorials_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
