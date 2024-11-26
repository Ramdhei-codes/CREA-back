namespace CREA_back_domain.Entities
{
    public class Class
    {
        public Guid Id { get; set; }
        public Guid ClassRoomId { get; set; }
        public string? Responsible { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public Classroom? Classroom { get; set; }
    }
}
