using CREA_back_application.DataAccess;
using CREA_back_domain.Entities;
using CREA_back_domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CREA_back_application.Services.Impl
{
    public class ListClassroomsService : IListClassroomsService
    {
        private readonly ClassroomsDbContext _context;

        public ListClassroomsService(ClassroomsDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClassResponseModel>> ListClassrooms()
        {
            List<ClassResponseModel> response = new List<ClassResponseModel>(); 
            List<Classroom> classrooms = await _context.Classrooms.ToListAsync();

            foreach (Classroom classroom in classrooms)
            {
                int currentHour = DateTime.Now.Hour;

                List<Class> classes = await _context.Classes.ToListAsync();

                Class? currentClass = classes.Where(c => c.ClassRoomId == classroom.Id &&
                                c.DayOfWeek == DateTime.Now.DayOfWeek &&
                                c.StartTime.Hour <= currentHour &&
                                c.EndTime.Hour > currentHour).FirstOrDefault();
                    
                if (currentClass != null)
                {
                    response.Add(new ClassResponseModel
                    {
                        Id = classroom.Id,
                        Name = classroom.Name,
                        Responsible = currentClass.Responsible,
                        StartDate = DateTime.Today.AddHours(currentClass.StartTime.Hour),
                        EndDate = DateTime.Today.AddHours(currentClass.EndTime.Hour),
                        Status = ClassroomStatus.Busy,
                    });
                }
                else
                {
                    response.Add(new ClassResponseModel
                    {
                        Id = classroom.Id,
                        Name = classroom.Name,
                        Status = ClassroomStatus.Available,
                    });
                }
            }

            return response.OrderByDescending(model => model.Status).ToList();
        }
    }

    public class ClassResponseModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Responsible { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ClassroomStatus Status { get; set; }
    }
}