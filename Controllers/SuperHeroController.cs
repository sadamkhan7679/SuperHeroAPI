using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
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
        
        
        
       [HttpGet]
       
       public async Task <ActionResult<List<SuperHero>>> GetSuperHeroes()
       {
           
           return Ok(_superHeroes);
       }
       
       
       [HttpGet]
       [Route("{id}")]
       public async Task <ActionResult<SuperHero>> GetSuperHero(int id)
       {
           var hero = _superHeroes.Find(x => x.Id == id);
           
           if (hero == null)
           {
               return NotFound();
           }
           return Ok(hero);
       }
       
       [HttpPost]
       public async Task <ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
       {
              _superHeroes.Add(hero);
           return Ok(_superHeroes);
       }
       
       [HttpPut]
       public async Task <ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero)
       {
              var heroToUpdate = _superHeroes.Find(x => x.Id == hero.Id);
              
              if (heroToUpdate == null)
              {
                return NotFound();
              }
              
              heroToUpdate.Name = hero.Name;
              heroToUpdate.FirstName = hero.FirstName;
              heroToUpdate.LastName = hero.LastName;
              heroToUpdate.Place = hero.Place;
              
              return Ok(_superHeroes);
       }
       
       [HttpDelete]
         [Route("{id}")]
       public async Task <ActionResult<List<SuperHero>>> RemoveSuperHero(int  id)
       {
                var heroToRemove = _superHeroes.Find(x => x.Id == id);
                
                if (heroToRemove == null)
                {
                    return NotFound();
                }
                
                _superHeroes.Remove(heroToRemove);
                
                return Ok(_superHeroes);
       }
    }
}
