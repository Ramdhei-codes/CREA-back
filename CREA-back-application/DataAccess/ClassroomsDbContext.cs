using CREA_back_domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CREA_back_application.DataAccess
{
    public class ClassroomsDbContext : DbContext
    {
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Class> Classes { get; set; }

        public ClassroomsDbContext(DbContextOptions<ClassroomsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.HasKey(classroom => classroom.Id);

                entity.HasMany(classroom => classroom.Classes)
                .WithOne(entity => entity.Classroom)
                .HasForeignKey(space => space.ClassRoomId);
            });
        }
    }
}
