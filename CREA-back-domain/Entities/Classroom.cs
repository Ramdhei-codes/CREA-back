using CREA_back_domain.Enums;

namespace CREA_back_domain.Entities
{
    public class Classroom
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Responsible { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ClassroomStatus? Status { get; set; }
    }
}
