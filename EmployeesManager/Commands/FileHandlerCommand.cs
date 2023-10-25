using EmployeesManager.Abstractions;
using EmployeesManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Commands
{
    public class FileHandlerCommand : BaseCommand
    {
        private Func<object, Task> _action;

        public FileHandlerCommand(Func<object, Task> action, Type t)
        {
            _action = action;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            await _action?.Invoke(parameter);
        }
    }
}
