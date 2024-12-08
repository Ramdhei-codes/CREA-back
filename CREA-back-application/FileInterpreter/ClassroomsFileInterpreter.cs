using CREA_back_application.FileInterpreter.Models;
using Ganss.Excel;

namespace CREA_back_application.FileInterpreter
{
    public class ClassroomsFileInterpreter
    {
        private readonly ExcelMapper excelMapper;

        public ClassroomsFileInterpreter(Stream stream)
        {
            excelMapper = new ExcelMapper(stream) { HeaderRow = true };
        }

        public IEnumerable<ClassModel> GetClassModels()
        {
            return excelMapper.Fetch<ClassModel>("Proyección Final");
        }
    }
}
