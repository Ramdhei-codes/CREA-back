using CREA_back_application.DataAccess;
using CREA_back_application.FileInterpreter;
using CREA_back_application.FileInterpreter.Models;
using CREA_back_domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CREA_back_application.Services.Impl
{
    public class ReadClassroomsFileService : IReadClassroomsFileService
    {
        private readonly ClassroomsDbContext _context;

        public ReadClassroomsFileService(ClassroomsDbContext context)
        {
            _context = context;
        }

        public async Task AddClasses(Stream stream)
        {
            DeleteAllClasses();
            ClassroomsFileInterpreter interpreter = new(stream);
            IEnumerable<ClassModel> classModels = interpreter.GetClassModels();
            await MapExcelRowsToClasses(classModels);
        }

        private void DeleteAllClasses()
        {
            _context.Classes.RemoveRange(_context.Classes.ToArray());
        }

        private async Task MapExcelRowsToClasses(IEnumerable<ClassModel> classModels)
        {
            foreach(ClassModel classModel in classModels)
            {
                await MapClassesFromClassModel(classModel);
            }
        }

        private async Task MapClassesFromClassModel(ClassModel classModel)
        {
            await AddClassToDatabase(await MapClass(classModel.Teacher, classModel.MondayClassrooom, classModel.MondayHour, DayOfWeek.Monday));
            await AddClassToDatabase(await MapClass(classModel.Teacher, classModel.TuesdayClassrooom, classModel.TuesdayHour, DayOfWeek.Tuesday));
            await AddClassToDatabase(await MapClass(classModel.Teacher, classModel.WednesdayClassrooom, classModel.WednesdayHour, DayOfWeek.Wednesday));
            await AddClassToDatabase(await MapClass(classModel.Teacher, classModel.ThursdayClassrooom, classModel.ThursdayHour, DayOfWeek.Thursday));
            await AddClassToDatabase( await MapClass(classModel.Teacher, classModel.FridayClassrooom, classModel.FridayHour, DayOfWeek.Friday));
            await AddClassToDatabase( await MapClass(classModel.Teacher, classModel.SaturdayClassrooom, classModel.SaturdayHour, DayOfWeek.Saturday));
            await _context.SaveChangesAsync();
        }

        private async Task AddClassToDatabase(Class? classToAdd)
        {
            if (classToAdd != null) await _context.Classes.AddAsync(classToAdd);
        }

        private async Task<Class?> MapClass(string? responsible, string? classroomName, string? classroomTime , DayOfWeek dayOfWeek)
        {
            if (string.IsNullOrEmpty(classroomName) || string.IsNullOrEmpty(classroomTime)) return null;

            int[] mappedTime = classroomTime.Split('-').Select(classTime => int.Parse(classTime)).ToArray();

            Classroom? classroom = await _context.Classrooms.Where(classroom => classroom.Name!.Equals(classroomName)).FirstOrDefaultAsync();

            if (classroom == null)
            {
                classroom = new Classroom
                {
                    Name = classroomName,
                };
                await _context.Classrooms.AddAsync(classroom);
                await _context.SaveChangesAsync();
            }

            TimeOnly startTime = new TimeOnly(mappedTime[0], 0);

            return new Class()
            {
                ClassRoomId = classroom.Id,
                Responsible = responsible,
                StartTime = startTime,
                EndTime = startTime.AddHours(mappedTime[1]),
                DayOfWeek = dayOfWeek
            };
        }
    }
}
