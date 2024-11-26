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
        }

        [Test]
        public void ListBusyClassroomsTest()
        {
            List<Classroom> list = _service.ListClassroomsByStatus(ClassroomStatus.Busy);

            Assert.That(list.Any(), Is.True);
        }

        [Test]
        public void ReturnEmptyListWithInvalidStatus()
        {
            List<Classroom> list = _service.ListClassroomsByStatus((ClassroomStatus)999);

            Assert.That(list, Is.Not.Null);
            Assert.That(list, Is.Empty);
        }
    }
}