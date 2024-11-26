using CREA_back_domain.Entities;
using CREA_back_domain.Enums;
using System.Linq;

namespace CREA_back_application.Services.Impl
{
    public class ListClassroomsService : IListClassroomsService
    {
        private readonly List<Classroom> _classrooms;

        public ListClassroomsService()
        {
            _classrooms = new List<Classroom>
            {
                new Classroom
                {
                    Id = Guid.NewGuid(),
                    Name = "Sala J",
                },
                new Classroom
                {
                    Id = Guid.NewGuid(),
                    Name = "D218",
                },
                new Classroom
                {
                    Id = Guid.NewGuid(),
                    Name = "D320",
                },
                new Classroom
                {
                    Id = Guid.NewGuid(),
                    Name = "Sala D",
                },
                new Classroom
                {
                    Id = Guid.NewGuid(),
                    Name = "Sala I",
                },
                new Classroom
                {
                    Id = Guid.NewGuid(),
                    Name = "D221"
                },
                new Classroom
                {
                    Id = Guid.NewGuid(),
                    Name = "D120"
                },
            };
        }

        public List<Classroom> ListClassrooms()
        {
            return _classrooms;
        }

        public List<Classroom> ListClassroomsByStatus(ClassroomStatus status)
        {
            return _classrooms;
        }
    }
}