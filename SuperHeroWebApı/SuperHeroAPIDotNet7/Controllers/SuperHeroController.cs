using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPIDotNet7.Services;

namespace SuperHeroAPIDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            //Dependency Injection
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroesAsync()
        {
            return await _superHeroService.GetAllHeroesAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetByIdHeroAsync(int id)
        {

            var result = await _superHeroService.GetByIdHeroAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]

        public async Task<ActionResult<List<SuperHero>>> AddSuperHeroAsync(SuperHero hero)
        {
            var result = await _superHeroService.AddSuperHeroAsync(hero);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateSuperHeroAsync(int id, SuperHero hero)
        {
            var result =  await  _superHeroService.UpdateSuperHeroAsync(id, hero);

            if (result== null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        {
           var result =  await _superHeroService.DeleteSuperHeroAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
