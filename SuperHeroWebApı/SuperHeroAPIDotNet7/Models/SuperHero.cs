using Microsoft.VisualBasic;

namespace SuperHeroAPIDotNet7.Models
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Place { get; set; }
        public string? Enemy { get; set; }
        public int PowerRate { get; set; }
    }
}
