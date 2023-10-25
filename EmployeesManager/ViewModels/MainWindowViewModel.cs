using EmployeesManager.Abstractions;
using EmployeesManager.Commands;
using EmployeesManager.Helpers;
using EmployeesManager.Models;
using EmployeesManager.Services;
using EmployeesManager.Services.Interfaces;
using EmployeesManager.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.ViewModels
{
    public class MainWindowViewModel : BaseNotifyPropertyChanged
    {
        private static IEmployeesService _employeesService;
        private static Mapper _mapper;

        public MainWindowViewModel(IEmployeesService employeesService, Mapper mapper, IDialogService dialogService)
        {
            _employeesService = employeesService;
            _mapper = mapper;

            App.Current.Dispatcher.Invoke(async () =>
            {
                await LoadEmployees();
            });
        }

        public ObservableCollection<Employee> Employees => Models.EmployeesManager.Employees;

        public ShowWindowCommand ShowWindowCommand => new ShowWindowCommand(ShowAddEmployeeWindow);

        public string FileHandlerExecutionClass { get; set; }

        public FileHandlerCommand FileHandlerCommand =>
                  new FileHandlerCommand(FileHandlerExecutionClass, Employees);

        private string _searchFilter;

        public string SearchFilter
        {
            get
            {
                return _searchFilter;
            }
            set
            {
                SetField<string>(ref _searchFilter, value);

                _searchFilter = value;
                LoadEmployeesByName();
            }
        }

        private async Task LoadEmployees()
        {
            var employees = await _employeesService.GetEmployees();

            foreach (var employee in employees)
            {
                try
                {
                    Models.EmployeesManager.Employees.Add(employee);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private async Task LoadEmployeesByName()
        {
            var employees = await _employeesService.GetEmployeesByName(_searchFilter);

            Models.EmployeesManager.Employees.Clear();

            foreach (var employee in employees)
            {
                try
                {
                    Models.EmployeesManager.Employees.Add(employee);
                }
                catch (Exception ex)
                {

                }
            }



        }

        private  async Task ShowAddEmployeeWindow(object parameter)
        {
            var window = new CreateEmployeeWindow(_employeesService, _mapper);

            window.ShowDialog();
        }
    }
}
