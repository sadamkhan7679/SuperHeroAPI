using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services.SuperHeroService;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        
        private readonly ISuperHeroService _superHeroService; 
        
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }



        [HttpGet]
       
       public async Task <ActionResult<List<SuperHero>>> GetSuperHeroes()
       {
           var superHeroes = _superHeroService.getSuperHeroes();
           
           return Ok(superHeroes);
       }
       
       
       [HttpGet]
       [Route("{id:int}")]
       public async Task <ActionResult<SuperHero>> GetSuperHero(int id)
       {
           var hero = _superHeroService.getSuperHero(id);
           
           if (hero == null)
           {
               return NotFound();
           }
           return Ok(hero);
       }
       
       [HttpPost]
       public async Task <ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
       {
        var heroes = _superHeroService.createSuperHero(hero);

        return Ok(heroes);
       }
       
       [HttpPut]
       public async Task <ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero hero)
       {
              var updatedHero = _superHeroService.updateSuperHero(hero);
              
                if (updatedHero == null)
                {
                    return NotFound();
                }
                
                return Ok(updatedHero);
       }
       
       [HttpDelete]
         [Route("{id:int}")]
       public async Task <ActionResult<List<SuperHero>>> RemoveSuperHero(int  id)
       {
                var result = _superHeroService.removeSuperHero(id);
                
                if (result == null)
                {
                    return NotFound();
                }
                
                return Ok(result);
       }
    }
}
