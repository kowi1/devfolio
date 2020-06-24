using Microsoft.EntityFrameworkCore;

namespace gtbweb.Models
{
    public class ServiceDbContext : DbContext
    {
    
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {
        }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Proficiency> Proficiencies { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCollection> ServiceCollections { get; set; }

        
    }
}