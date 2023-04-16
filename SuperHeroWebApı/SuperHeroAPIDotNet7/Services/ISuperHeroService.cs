namespace SuperHeroAPIDotNet7.Services
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroesAsync();
        Task<SuperHero> GetByIdHeroAsync(int id);
        Task<List<SuperHero>> AddSuperHeroAsync(SuperHero hero);
        Task<SuperHero> UpdateSuperHeroAsync(int id, SuperHero hero);
        Task<List<SuperHero>> DeleteSuperHeroAsync(int id);
    }
}
