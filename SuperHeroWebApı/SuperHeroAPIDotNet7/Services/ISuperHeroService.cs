namespace SuperHeroAPIDotNet7.Services
{
    public interface ISuperHeroService
    {
        List<SuperHero> GetAllHeroesAsync();
        SuperHero GetByIdHeroAsync(int id);
        List<SuperHero> AddSuperHeroAsync(SuperHero hero);
        SuperHero UpdateSuperHeroAsync(int id, SuperHero hero);
        List<SuperHero> DeleteSuperHero(int id);
    }
}
