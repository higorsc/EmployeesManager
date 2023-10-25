using EmployeesManager.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Commands
{
    public class CreateEmployeeCommand : BaseCommand
    {
        private Func<object, Task> _action;

        public CreateEmployeeCommand(Func<object, Task> action)
        {
            _action = action;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            _action?.Invoke(parameter);
        }
    }
}
