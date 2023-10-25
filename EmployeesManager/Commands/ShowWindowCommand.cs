using EmployeesManager.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Commands
{
    public class ShowWindowCommand : BaseCommand
    {
        private Func<object, Task> _action;

        public ShowWindowCommand(Func<object, Task> action)
        {
            _action = action;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            await _action?.Invoke(parameter);
        }
    }
}
