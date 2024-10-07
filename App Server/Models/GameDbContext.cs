using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace App_Server.Models;

public partial class GameDbContext : DbContext
{
    public GameDbContext()
    {
    }

    public GameDbContext(DbContextOptions<GameDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Initial Catalog=Game_DB;User ID=TaskAdminLogin;Password=DBGalPass;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("PK__Cards__55FECD8ED3FEEAF6");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("PK__Games__2AB897DDA895B4B6");

            entity.HasOne(d => d.LoserNavigation).WithMany(p => p.GameLoserNavigations).HasConstraintName("FK__Games__Loser__2B3F6F97");

            entity.HasOne(d => d.WinnerNavigation).WithMany(p => p.GameWinnerNavigations).HasConstraintName("FK__Games__Winner__2A4B4B5E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__Users__536C85E59D55815B");

            entity.HasOne(d => d.Type).WithMany(p => p.Users).HasConstraintName("FK__Users__TypeID__276EDEB3");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__UserType__516F03959AAEC60E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
