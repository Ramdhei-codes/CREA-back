using Ganss.Excel;

namespace CREA_back_application.FileInterpreter.Models
{
    public class ClassModel
    {
        [Column("Departamento", MappingDirections.ExcelToObject)]
        public string? Department { get; set; }

        [Column("Código", MappingDirections.ExcelToObject)]
        public string? Code { get; set; }

        [Column("Materia", MappingDirections.ExcelToObject)]
        public string? Subject { get; set; }

        [Column("Profesor", MappingDirections.ExcelToObject)]
        public string? Teacher { get; set; }

        [Column("Lu hora", MappingDirections.ExcelToObject)]
        public string? MondayHour { get; set; }

        [Column("Lu sala", MappingDirections.ExcelToObject)]
        public string? MondayClassrooom { get; set; }

        [Column("Ma hora", MappingDirections.ExcelToObject)]
        public string? TuesdayHour { get; set; }

        [Column("Ma sala", MappingDirections.ExcelToObject)]
        public string? TuesdayClassrooom { get; set; }

        [Column("Mie hora", MappingDirections.ExcelToObject)]
        public string? WednesdayHour { get; set; }

        [Column("Mie sala", MappingDirections.ExcelToObject)]
        public string? WednesdayClassrooom { get; set; }

        [Column("Ju hora", MappingDirections.ExcelToObject)]
        public string? ThursdayHour { get; set; }

        [Column("Ju sala", MappingDirections.ExcelToObject)]
        public string? ThursdayClassrooom { get; set; }

        [Column("Vi hora", MappingDirections.ExcelToObject)]
        public string? FridayHour { get; set; }

        [Column("Vi sala", MappingDirections.ExcelToObject)]
        public string? FridayClassrooom { get; set; }

        [Column("Sa hora", MappingDirections.ExcelToObject)]
        public string? SaturdayHour { get; set; }

        [Column("Sa sala", MappingDirections.ExcelToObject)]
        public string? SaturdayClassrooom { get; set; }
    }
}
