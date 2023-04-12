using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPIDotNet7.Models;

namespace SuperHeroAPIDotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id= 1,
                    Name = "Batman",
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Place = "Gotham",
                    Enemy = "Joker",
                    PowerRate= 91
                },
                new SuperHero
                {
                    Id= 2,
                    Name = "IronMan",
                    FirstName = "Tony",
                    LastName = "Stark",
                    Place = "New York City",
                    Enemy = "Thanos",
                    PowerRate = 97
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroesAsync()
        {

            return Ok(heroes);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetByIdHeroAsync(int id)
        {

            foreach (var h in heroes)
            {
                if (h.Id == id)
                    return Ok(h);
            };
            // var hero = heroes.Find(x => x.Id == id);
            return NotFound("Sorry .This hero does not exist !");
        }


    }
}
