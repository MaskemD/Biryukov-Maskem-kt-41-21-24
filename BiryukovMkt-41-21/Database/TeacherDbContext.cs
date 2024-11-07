using BiryukovMkt_41_21.Database.Configurations;
using BiryukovMkt_41_21.Models;
using Microsoft.EntityFrameworkCore;

namespace BiryukovMkt_41_21.Database
{
    public class TeacherDbContext : DbContext
    {
        DbSet<Cathedra> Cathedras { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Discipline> Disciplines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CathedraConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
        }

        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options) { }
    }
}
