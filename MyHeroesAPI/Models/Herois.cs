using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHeroesAPI.Models;

public class Heroi
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(120)]
    public string Nome { get; set; }

    [Required]
    [MaxLength(120)]
    public string NomeHeroi { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    public float Altura { get; set; }

    [Required]
    public float Peso { get; set; }

    public ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; set; } = new List<HeroisSuperpoderes>();

    //facilita conversão
    public Heroi ToHero(Heroi hero)
    {
        Id = hero.Id;
        Nome = hero.Nome;
        NomeHeroi = hero.NomeHeroi;
        DataNascimento = hero.DataNascimento;
        Altura = hero.Altura;
        Peso = hero.Peso;

        return hero;
    }
}

public class Superpoderes
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Superpoder { get; set; }

    [MaxLength(250)]
    public string? Descricao { get; set; }

    public ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; set; } = new List<HeroisSuperpoderes>();
}

public class HeroisSuperpoderes
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Heroi")]
    public int HeroiId { get; set; }
    public Heroi Heroi { get; set; }

    [ForeignKey("Superpoderes")]
    public int SuperpoderId { get; set; }
    public Superpoderes Superpoderes { get; set; }
}
