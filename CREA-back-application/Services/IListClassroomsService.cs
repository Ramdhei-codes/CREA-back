using CREA_back_domain.Entities;
using CREA_back_domain.Enums;

namespace CREA_back_application.Services
{
    public interface IListClassroomsService
    {
        List<Classroom> ListClassrooms();
        List<Classroom> ListClassroomsByStatus(ClassroomStatus status);
    }
}
