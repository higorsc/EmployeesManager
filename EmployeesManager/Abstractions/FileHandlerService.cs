using EmployeesManager.Abstractions;
using EmployeesManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Services
{
    public abstract class FileHandler : IBaseFileHandler
    {
        public abstract Task SaveFile<T>(List<T> collection, string path);
    }
}
