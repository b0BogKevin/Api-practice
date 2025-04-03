using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiProj.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<Story> Stories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=database.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e=>e.Id);

            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
        });

        modelBuilder.Entity<Story>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
