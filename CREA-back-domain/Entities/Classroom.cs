using CREA_back_domain.Enums;

namespace CREA_back_domain.Entities
{
    public class Classroom
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<Class>? Classes { get; set; }
    }
}
