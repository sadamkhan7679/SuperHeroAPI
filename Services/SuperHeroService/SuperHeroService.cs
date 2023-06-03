using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;


namespace SuperHeroAPI.Services.SuperHeroService;

public class SuperHeroService : ISuperHeroService
{
    /* private static List<SuperHero> _superHeroes = new List<SuperHero>
    {
        new SuperHero
        {
            Id = 1, 
            Name = "Spider Man", 
            FirstName = "Peter", 
            LastName = "Parker", 
            Place = "New York"
        },
        new SuperHero
        {
            Id = 2, 
            Name = "Iron Man", 
            FirstName = "Tony", 
            LastName = "Stark", 
            Place = "New York"
        },
    };
    */


    private readonly DataContext _context;

    public SuperHeroService(DataContext context)
    {
        _context = context;
    }


    public async Task<List<SuperHero>> GetSuperHeroes()
    {
        var superHeroes = await _context.SuperHeroes.ToListAsync();
        return superHeroes;
    }

    public async Task<SuperHero?> GetSuperHero(int id)
    {
        //var hero = _superHeroes.Find(x => x.Id == id);

        var hero = await _context.SuperHeroes.FindAsync(id);

        return hero ?? null;
    }

    public async Task<List<SuperHero>> CreateSuperHero(SuperHero hero)
    {
        await _context.SuperHeroes.AddAsync(hero);
        await _context.SaveChangesAsync();

        return await _context.SuperHeroes.ToListAsync();
    }

    public async Task<SuperHero?> UpdateSuperHero(SuperHero hero)
    {
        
        var heroToUpdate = await _context.SuperHeroes.FindAsync(hero.Id);

        if (heroToUpdate == null)
        {
            return null;
        }

        heroToUpdate.Name = hero.Name;
        heroToUpdate.FirstName = hero.FirstName;
        heroToUpdate.LastName = hero.LastName;
        heroToUpdate.Place = hero.Place;

        await _context.SaveChangesAsync();

        return heroToUpdate;
     
        
    }

    public async Task<SuperHero?>  RemoveSuperHero(int id)
    {
        
        var heroToRemove = await _context.SuperHeroes.FindAsync(id);

        if (heroToRemove == null)
        {
            return null;
        }

        _context.SuperHeroes.Remove(heroToRemove);
        await _context.SaveChangesAsync();

        return heroToRemove;
    }
}