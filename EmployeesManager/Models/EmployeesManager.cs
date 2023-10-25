using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Models
{
    public class EmployeesManager
    {
        public static ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
    }
}
