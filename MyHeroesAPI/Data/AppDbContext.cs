using Microsoft.EntityFrameworkCore;
using MyHeroesAPI.Models;

namespace MyHeroesAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Heroi> Herois { get; set; }
    public DbSet<Superpoderes> Superpoderes { get; set; }
    public DbSet<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração da tabela HeroisSuperpoderes
        modelBuilder.Entity<HeroisSuperpoderes>()
            .HasKey(hs => hs.Id);

        modelBuilder.Entity<HeroisSuperpoderes>()
            .HasOne(hs => hs.Heroi)
            .WithMany(h => h.HeroisSuperpoderes)
            .HasForeignKey(hs => hs.HeroiId);

        modelBuilder.Entity<HeroisSuperpoderes>()
            .HasOne(hs => hs.Superpoderes)
            .WithMany(s => s.HeroisSuperpoderes)
            .HasForeignKey(hs => hs.SuperpoderId);

        //necessario setar manualmente o Id para que a tabela inicie preenchida
        modelBuilder.Entity<Superpoderes>().HasData(
            new Superpoderes { Id = 1, Superpoder = "Vôo" },
            new Superpoderes { Id = 2, Superpoder = "Super Força" },
            new Superpoderes { Id = 3, Superpoder = "Telepatia" },
            new Superpoderes { Id = 4, Superpoder = "Invisibilidade" },
            new Superpoderes { Id = 5, Superpoder = "Super velocidade" },
            new Superpoderes { Id = 6, Superpoder = "Teletransporte" },
            new Superpoderes { Id = 7, Superpoder = "Regeneração Acelerada" },
            new Superpoderes { Id = 8, Superpoder = "Manipulação de Elementos" },
            new Superpoderes { Id = 9, Superpoder = "Campo de Força" },
            new Superpoderes { Id = 10, Superpoder = "Controle Mental" }
        );
    }
}
