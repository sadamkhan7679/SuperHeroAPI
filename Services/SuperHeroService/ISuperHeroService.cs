using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services.SuperHeroService;

public interface ISuperHeroService
{
    List<SuperHero> getSuperHeroes();
    
    
    SuperHero? getSuperHero(int id);
    
    
    List<SuperHero>? createSuperHero(SuperHero hero);
    
    
    SuperHero updateSuperHero(SuperHero hero);
    
    
    SuperHero removeSuperHero(int id);
}