using System.ComponentModel.DataAnnotations;

namespace CREA_back.Models
{
    public class Classroom
    {
        [Key]
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Manager { get; set; }
        public string Status { get; set; }

    }

    public enum Status
    {
        Available,
        NotAvailable
    }
}
