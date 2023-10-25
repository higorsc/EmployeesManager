using EmployeesManager.Models;
using EmployeesManager.Models.DTO;
using EmployeesManager.Repositories.Interfaces;
using EmployeesManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesService(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _employeesRepository.GetEmployees();
        }

        public async Task<List<Employee>> GetEmployeesByName(string name)
        {
            return await _employeesRepository.GetEmployeesByName(name);
        }

        public async Task<EmployeeDTO> AddEmployee(EmployeeDTO employee)
        {
            return await _employeesRepository.AddEmployee(employee);
        }

    }
}
