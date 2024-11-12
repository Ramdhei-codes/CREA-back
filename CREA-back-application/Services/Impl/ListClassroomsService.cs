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
                    Responsible = "Carlos Cuesta Iglesias",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddHours(2),
                    Status = ClassroomStatus.Busy,
                },
                new Classroom
                {
                    Id = Guid.NewGuid(),
                    Name = "D218",
                    Responsible = "Andres Paolo",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddHours(2),
                    Status = ClassroomStatus.Busy,
                },
                new Classroom
                {
                    Id = Guid.NewGuid(),
                    Name = "D320",
                    Responsible = "Marcelo Lopez",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddHours(2),
                    Status = ClassroomStatus.Busy,
                },
                new Classroom
                {
                    Id = Guid.NewGuid(),
                    Name = "Sala D",
                    Responsible = "Marcelo Herrera",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddHours(2),
                    Status = ClassroomStatus.Busy,
                },
                new Classroom
                {
                    Id = Guid.NewGuid(),
                    Name = "Sala I",
                    Status = ClassroomStatus.Available,
                },
                new Classroom
                {
                    Id = Guid.NewGuid(),
                    Name = "D221",
                    Status = ClassroomStatus.Available,
                },
                new Classroom
                {
                    Id = Guid.NewGuid(),
                    Name = "D120",
                    Status = ClassroomStatus.Available,
                },
            };
        }

        public List<Classroom> ListClassrooms()
        {
            return _classrooms;
        }

        public List<Classroom> ListClassroomsByStatus(ClassroomStatus status)
        {
            return _classrooms.Where(c => c.Status == status).ToList();
        }
    }
}