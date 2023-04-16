using Microsoft.AspNetCore.Http.HttpResults;
using SuperHeroAPIDotNet7.Data;

namespace SuperHeroAPIDotNet7.Services
{
    public class SuperHeroService : ISuperHeroService
    {

        private readonly DataContext _context;
        public SuperHeroService(DataContext context)
        {
            _context= context;
        }
        public async Task<List<SuperHero>> AddSuperHeroAsync(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }

        public async  Task<List<SuperHero>> DeleteSuperHeroAsync(int id)
        {

            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero == null)
                return null;

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }

        public async  Task<List<SuperHero>> GetAllHeroesAsync()
        {
            var heroes = await  _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero> GetByIdHeroAsync(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            return hero;
        }

        public async Task<SuperHero> UpdateSuperHeroAsync(int id, SuperHero hero)
        {
            var h = await _context.SuperHeroes.FindAsync(id);

            if (h == null)
                return null;

            h.Name = hero.Name;
            h.FirstName = hero.FirstName;
            h.LastName = hero.LastName;
            h.Place = hero.Place;
            h.Enemy = hero.Enemy;
            h.PowerRate = hero.PowerRate;

            await _context.SaveChangesAsync();

            return h;
        }
    }
}
