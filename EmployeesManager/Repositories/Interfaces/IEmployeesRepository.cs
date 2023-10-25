using EmployeesManager.Models;
using EmployeesManager.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesManager.Repositories.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<EmployeeDTO> AddEmployee(EmployeeDTO employee);
        Task<List<Employee>> GetEmployees();
        Task<List<Employee>> GetEmployeesByName(string name);
    }
}