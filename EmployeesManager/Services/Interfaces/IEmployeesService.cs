using EmployeesManager.Models;
using EmployeesManager.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesManager.Services.Interfaces
{
    public interface IEmployeesService
    {
        Task<EmployeeDTO> AddEmployee(EmployeeDTO employee);
        Task<List<Employee>> GetEmployees();
        Task<List<Employee>> GetEmployeesByName(string name);
    }
}