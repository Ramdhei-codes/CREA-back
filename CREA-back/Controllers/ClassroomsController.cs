using CREA_back_application.Services;
using CREA_back_application.Services.Impl;
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
        private IReadClassroomsFileService _readClassroomsFileService;

        public ClassroomsController(IListClassroomsService listClassroomsService, IReadClassroomsFileService readClassroomsFileService)
        {
            _listClassroomsService = listClassroomsService;
            _readClassroomsFileService = readClassroomsFileService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IEnumerable<ClassResponseModel>> List()
        {
            return await _listClassroomsService.ListClassrooms();
        }

        [HttpPost]
        [Route("classrooms_load_file")]
        public async Task LoadClassroomsFromExcelAsync(IFormFile file)
        {
            await _readClassroomsFileService.AddClasses(file.OpenReadStream());
        }
    }
}
