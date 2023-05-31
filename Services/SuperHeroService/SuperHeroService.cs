using SuperHeroAPI.Models;


namespace SuperHeroAPI.Services.SuperHeroService;

public class SuperHeroService : ISuperHeroService
{
    private static List<SuperHero> _superHeroes = new List<SuperHero>
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
    
    public List<SuperHero> getSuperHeroes()
    {
        return _superHeroes;
    }

    public SuperHero? getSuperHero(int id)
    {
        var hero = _superHeroes.Find(x => x.Id == id);
        
        return hero ?? null;
    }

    public List<SuperHero> createSuperHero(SuperHero hero)
    {
       _superHeroes.Add(hero);
       return _superHeroes;
    }

    public SuperHero updateSuperHero(SuperHero hero)
    {
        var heroToUpdate = _superHeroes.Find(x => x.Id == hero.Id);
              
        if (heroToUpdate == null)
        {
            return null;
        }
              
        heroToUpdate.Name = hero.Name;
        heroToUpdate.FirstName = hero.FirstName;
        heroToUpdate.LastName = hero.LastName;
        heroToUpdate.Place = hero.Place;
              
        return heroToUpdate;
    }

    public SuperHero removeSuperHero(int id)
    {
        var heroToRemove = _superHeroes.Find(x => x.Id == id);
                
        if (heroToRemove == null)
        {
            return null;
        }
                
        _superHeroes.Remove(heroToRemove);
                
        return heroToRemove;
    }
}