using Microsoft.EntityFrameworkCore;

namespace gtbweb.Models
{
    public class AboutDbContext : DbContext
    {
    
        public AboutDbContext(DbContextOptions<AboutDbContext> options) : base(options)
        {
        }
        
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Proficiency> Proficiencies { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        
    }
}