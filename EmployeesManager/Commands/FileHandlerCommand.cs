using EmployeesManager.Abstractions;
using EmployeesManager.Models;
using EmployeesManager.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Commands
{
    public class FileHandlerCommand : BaseCommand
    {
        private Func<object, Task> _action;
        private readonly ObservableCollection<Employee> _employees;
        private readonly string _handlerClassName;

        public FileHandlerCommand(Func<object, Task> action, Type t)
        {
            _action = action;
        }

        public FileHandlerCommand(string handlerClassName, ObservableCollection<Employee> employees)
        {
            _handlerClassName = handlerClassName;
            _employees = employees;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Comma Separated Values (*.csv)|*.csv";
            saveFileDialog.DefaultExt = "Comma Separated Values (*.csv)";
            saveFileDialog.ShowDialog();

            var fileName = saveFileDialog.FileName;

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(a => a.Name == parameter.ToString());

            var instance = (IBaseFileHandler)Activator.CreateInstance((type));
            instance.SaveFile<Employee>(_employees.ToList(), fileName);
        }
    }
}
