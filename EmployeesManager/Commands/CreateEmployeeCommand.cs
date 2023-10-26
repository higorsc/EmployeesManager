using EmployeesManager.Abstractions;
using EmployeesManager.Helpers;
using EmployeesManager.Models.DTO;
using EmployeesManager.Models;
using EmployeesManager.Services;
using EmployeesManager.Services.Interfaces;
using EmployeesManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static EmployeesManager.Models.Enums.GenderEnum;
using System.Windows;
using EmployeesManager.Views;

namespace EmployeesManager.Commands
{
    public class CreateEmployeeCommand : BaseCommand
    {
        private Func<object, Task> _action;

        private readonly IEmployeesService _employeeService;
        private readonly Mapper _mapper;
        private readonly CreateEmployeeViewModel _createEmployeeViewModel;

        public CreateEmployeeCommand(Func<object, Task> action)
        {
            _action = action;
        }

        public CreateEmployeeCommand(IEmployeesService employeeService, Mapper mapper, CreateEmployeeViewModel createEmployeeViewModel)
        {
            _mapper = mapper;
            _employeeService = employeeService;
            _createEmployeeViewModel = createEmployeeViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                var viewModel = parameter as CreateEmployeeViewModel;

                var employeeDto = new EmployeeDTO()
                {
                    Name = _createEmployeeViewModel.Name,
                    Gender = _createEmployeeViewModel.Genders.FirstOrDefault(a => a == _createEmployeeViewModel.Gender).ToString(),
                    Status = _createEmployeeViewModel.Statuses.FirstOrDefault(a => a == _createEmployeeViewModel.Status).ToString(),
                    Email = _createEmployeeViewModel.Email
                };

                var employee = new Employee();

                var createdEmployee = await _employeeService.AddEmployee(employeeDto);

                _mapper.CustomMapping(a => Mappings.MapEmployeesFromDTO(createdEmployee, employee));

                Models.EmployeesManager.Employees.Add(employee);
            }
            catch (Exception ex)
            {
                var dialog = new ErrorWindow(ex.Message);
                dialog.ShowDialog();
            }
            _action?.Invoke(parameter);
        }
    }
}
