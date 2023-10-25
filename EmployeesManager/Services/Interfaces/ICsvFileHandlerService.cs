using EmployeesManager.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesManager.Services
{
    public interface ICsvFileHandlerService : IBaseFileHandler
    {
        //Task SaveCsvFile<T>(List<T> collection, string path, string fileName);
    }
}