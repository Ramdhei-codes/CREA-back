using CREA_back.Models;
using Microsoft.EntityFrameworkCore;

namespace CREA_back
{
    public class ClassroomContext : DbContext
    {
        public ClassroomContext(DbContextOptions<ClassroomContext> options)
            : base(options)
        {
        }

        public DbSet<Classroom> Classrooms { get; set; }
    }
}
