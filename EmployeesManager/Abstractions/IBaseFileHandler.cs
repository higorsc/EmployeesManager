using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Abstractions
{
    public interface IBaseFileHandler
    {
        Task SaveFile<T>(List<T> collection, string path);
    }
}
