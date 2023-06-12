using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiDemo.Models;

public partial class StuinfoContext : DbContext
{
    public StuinfoContext()
    {
    }

    public StuinfoContext(DbContextOptions<StuinfoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Stuinfo> Stuinfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;uid=root;pwd=hfcn1224;database=stuinfo", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Stuinfo>(entity =>
        {
            entity.HasKey(e => e.Stuid).HasName("PRIMARY");

            entity.ToTable("stuinfos");

            entity.Property(e => e.Stuid).ValueGeneratedNever();
            entity.Property(e => e.Stuname)
                .HasMaxLength(255)
                .HasColumnName("stuname");
            entity.Property(e => e.Stusex)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("stusex");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
