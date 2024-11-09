using CREA_back_application.Services;
using CREA_back_domain.Entities;
using CREA_back_domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CREA_back.Controllers
{
    [ApiController]
    [Route("api/classrooms")]
    public class ClassroomsController : ControllerBase
    {
        private IListClassroomsService _listClassroomsService;

        public ClassroomsController(IListClassroomsService listClassroomsService)
        {
            _listClassroomsService = listClassroomsService;
        }

        [HttpGet(Name = "list")]
        public IEnumerable<Classroom> List()
        {
            return _listClassroomsService.ListClassrooms();
        }

        [HttpGet("status/{status}", Name = "listByStatus")]
        public IEnumerable<Classroom> ListByStatus(ClassroomStatus status)
        {
            return _listClassroomsService.ListClassroomsByStatus(status);
        }
    }
}
