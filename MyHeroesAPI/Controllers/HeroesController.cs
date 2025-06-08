using Microsoft.AspNetCore.Mvc;
using MyHeroesAPI.Data;
using MyHeroesAPI.Models;

namespace MyHeroesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HeroesController : ControllerBase
{
    private readonly AppDbContext _context;

    public HeroesController(AppDbContext context) 
    { 
        _context = context;
    }


    /// <summary>
    /// Get a list of all <see cref="Heroi"/> from the database
    /// </summary>
    /// <returns>List of <see cref="Heroi"/></returns>
    [HttpGet("/list")]
    public IActionResult GetHeroes() 
    {
        try
        {
            List<Heroi> heroes = _context.Herois.ToList();

            if(!heroes.Any())
            {
                return Ok(new {message = "Nenhum super-herói encontrado.", data = new List<int>()});
            }

            return Ok(heroes);
        }
        catch (Exception ex )
        {
            return BadRequest(ex.Message);
        }
    }


    /// <summary>
    /// Get a <see cref="Heroi"/> from the database by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns><see cref="Heroi"/></returns>
    [HttpGet("/getById")]
    public IActionResult GetById([FromQuery]int id) 
    {
        try
        {
            List<Heroi> heroes = _context.Herois.ToList();

            Heroi? hero = heroes.FirstOrDefault(h => h.Id == id);

            if(hero == null)
            {
                return NotFound("Super-herói não encontrado.");
            }

            return Ok(hero);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    /// <summary>
    /// Create a new <see cref="Heroi"/> and saves it to the database.
    /// </summary>
    /// <param name="model"></param>
    /// <returns><see cref="Heroi"/></returns>
    [HttpPost("/create")]
    public IActionResult Create([FromBody] Heroi model)
    {
        try
        {
            var result = new Heroi
            {
                Nome = model.Nome,
                NomeHeroi = model.NomeHeroi,
                DataNascimento = model.DataNascimento,
                Altura = model.Altura,
                Peso = model.Peso,
            };

            _context.Herois.Add(result);
            _context.SaveChanges();

            return Created(string.Empty, result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Update an existing <see cref="Heroi"/> with the provided information.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns>the updated <see cref="Heroi"/></returns>
    [HttpPut("/update")]
    public IActionResult Update([FromQuery]int id, [FromBody] Heroi model)
    {
        try
        {
            List<Heroi> heroes = _context.Herois.ToList();

            Heroi? hero = heroes.FirstOrDefault(h => h.Id == id);

            if (hero == null)
            {
                return NotFound("Super-herói não encontrado.");
            }

            hero.ToHero(model);

            _context.Herois.Update(hero);
            _context.SaveChanges();

            return Ok(hero);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Delete a <see cref="Heroi"/> from the database by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>NoContent</returns>
    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        try
        {
            List<Heroi> heroes = _context.Herois.ToList();

            Heroi? hero = heroes.FirstOrDefault(h => h.Id == id);

            if (hero == null)
            {
                return NotFound("Super-herói não encontrado.");
            }

            _context.Herois.Remove(hero);
            _context.SaveChanges();

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get a list of all <see cref="Superpoderes"/> from the database.
    /// </summary>
    /// <returns>List of <see cref="Superpoderes"/></returns>
    [HttpGet("/superPoderes")]
    public IActionResult GetSuperpoders()
    {
        try
        {
            List<Superpoderes> superpoderes = _context.Superpoderes.ToList();

            return Ok(superpoderes);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
