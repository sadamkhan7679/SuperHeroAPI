using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService;

public interface ISuperHeroService
{
    Task<List<SuperHero>> GetSuperHeroes();
    
    
    //SuperHero? getSuperHero(int id);
    
    Task<SuperHero?> GetSuperHero(int id); 


    //List<SuperHero>? createSuperHero(SuperHero hero);
    
    Task<List<SuperHero>> CreateSuperHero(SuperHero hero);
    
    //SuperHero updateSuperHero(SuperHero hero);
    
    Task<SuperHero?> UpdateSuperHero(SuperHero hero);
    
    
    //SuperHero removeSuperHero(int id);
    
    Task<SuperHero?> RemoveSuperHero(int id);
}