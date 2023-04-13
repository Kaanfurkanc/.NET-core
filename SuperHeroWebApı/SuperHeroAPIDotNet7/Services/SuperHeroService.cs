using Microsoft.AspNetCore.Http.HttpResults;

namespace SuperHeroAPIDotNet7.Services
{
    public class SuperHeroService : ISuperHeroService
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
        public List<SuperHero> AddSuperHeroAsync(SuperHero hero)
        {
            heroes.Add(hero);
            return heroes;
        }

        public List<SuperHero> DeleteSuperHero(int id)
        {
            foreach (var h in heroes)
            {
                if (h.Id == id)
                {
                    heroes.Remove(h);
                    return heroes;
                }
                    
            }

            return null;
        }

        public List<SuperHero> GetAllHeroesAsync()
        {
            return heroes;
        }

        public SuperHero GetByIdHeroAsync(int id)
        {
            foreach (var h in heroes)
            {
                if (h.Id == id)
                    return h;
            };
            // var hero = heroes.Find(x => x.Id == id);
            return null;
        }

        public SuperHero UpdateSuperHeroAsync(int id, SuperHero hero)
        {
            var h = heroes.Find(x => x.Id == id);

            if (h == null)
                return null;

            h.Name = hero.Name;
            h.FirstName = hero.FirstName;
            h.LastName = hero.LastName;
            h.Place = hero.Place;
            h.Enemy = hero.Enemy;
            h.PowerRate = hero.PowerRate;

            return h;
        }
    }
}
