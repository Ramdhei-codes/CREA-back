using CREA_back_application.Services.Impl;

namespace CREA_back_application.Services
{
    public interface IListClassroomsService
    {
        Task<List<ClassResponseModel>> ListClassrooms();
    }
}
