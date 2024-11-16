using CREA_back_application.Services;
using CREA_back_application.Services.Impl;
using CREA_back_domain.Entities;
using CREA_back_domain.Enums;
using Moq;

namespace CREA_back_test
{
    public class ListClassroomsTests
    {
        private IListClassroomsService _service;

        [SetUp]
        public void Setup()
        {
            _service = new ListClassroomsService();
        }

        [Test]
        public void ListAllClassroomsSuccessfullyTest()
        {
            List<Classroom> list = _service.ListClassrooms();

            Assert.That(list.Any(), Is.True);
        }

        [Test]
        public void ListAvailableClassroomsTest()
        {
            List<Classroom> list = _service.ListClassroomsByStatus(ClassroomStatus.Available);

            Assert.That(list.Any(), Is.True);
            Assert.That(list.All(classroom => classroom.Status == ClassroomStatus.Available), Is.True);
        }
    }
}