using System;
using System.Collections.Generic;
using BisnesManager.DatabasePersistens.Model;
using Microsoft.EntityFrameworkCore;

namespace BisnesManager.DatabasePersistens.Context;

public partial class BissnesExpertSystemDiplomaContext : DbContext
{
    public BissnesExpertSystemDiplomaContext()
    {
    }

    public BissnesExpertSystemDiplomaContext(DbContextOptions<BissnesExpertSystemDiplomaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BisnesTask> BisnesTasks { get; set; }

    public virtual DbSet<HolidayPlan> HolidayPlans { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Statistic> Statistics { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BissnesExpertSystem_Diploma7;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BisnesTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Tasks_pkey");

            entity.ToTable("BisnesTask");

            entity.Property(e => e.Id);//.HasDefaultValueSql("nextval('\"Id\"'::regclass)");
            entity.Property(e => e.AssignmentsContent)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.IdStatus).HasDefaultValueSql("nextval('\"Tasks_IdStatus_seq\"'::regclass)");
            entity.Property(e => e.IdUser).HasDefaultValueSql("nextval('\"Tasks_IdUser_seq\"'::regclass)");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.BisnesTasks)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tasks_IdStatus_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.BisnesTasks)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tasks_IdUser_fkey");
        });

        modelBuilder.Entity<HolidayPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("HolidayPlan_pkey");

            entity.ToTable("HolidayPlan");

            entity.Property(e => e.IdUser).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.HolidayPlans)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("HolidayPlan_IdUser_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Roles_pkey");

            entity.Property(e => e.Post)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsFixedLength();
        });

        modelBuilder.Entity<Statistic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Statistic_pkey");

            entity.ToTable("Statistic");

            entity.Property(e => e.IdUser).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Statistics)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Statistic_IdUser_fkey");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Statuses_pkey");

            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsFixedLength();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Users_pkey");

            entity.Property(e => e.CheckPhrase)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.EndWorkTime).HasColumnType("time with time zone");
            entity.Property(e => e.Family)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.IdRole).ValueGeneratedOnAdd();
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Patronymic)
                .HasMaxLength(255)
                .IsFixedLength();
            entity.Property(e => e.StartWorkTime).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Users_IdRole_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
