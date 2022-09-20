using Microsoft.EntityFrameworkCore;

namespace Training_Task.ModelEntities
{
    public class ModelDbContext : DbContext
    {
        public ModelDbContext(DbContextOptions<ModelDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillMap>().HasKey(sc => new { sc.EmployeeId, sc.SkillId });

            modelBuilder.Entity<SkillMap>()
                .HasOne<Employee>(sc => sc.Employees)
                .WithMany(s => s.SkillMaps)
                .HasForeignKey(sc => sc.EmployeeId);


            modelBuilder.Entity<SkillMap>()
                .HasOne<Skills>(sc => sc.Skills)
                .WithMany(s => s.SkillMaps)
                .HasForeignKey(sc => sc.SkillId);

          
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SkillMap> SkillMaps { get; set; }
        public DbSet<Skills> Skills { get; set; }
    }
}
