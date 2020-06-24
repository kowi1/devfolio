using Microsoft.EntityFrameworkCore;

namespace gtbweb.Models
{
    public class ArchiveDbContext : DbContext
    {
    
        public ArchiveDbContext(DbContextOptions<ArchiveDbContext> options) : base(options)
        {
                        
        }
        
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogCollection> BlogCollections{ get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BlogPage> BlogPages { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Proficiency> Proficiencies { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Archive> Archives { get; set; }
        public DbSet<DateArchive> DateArchives { get; set; }
        public DbSet<CategoryArchive> CategoryArchives { get; set; }
        public DbSet<ServiceCollection> ServiceCollections { get; set; }

        
    }
}