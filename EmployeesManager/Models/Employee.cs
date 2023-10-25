using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeesManager.Models.Enums.GenderEnum;
using static EmployeesManager.Models.Enums.StatusEnum;

namespace EmployeesManager.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public EmployeeStatus Status { get; set; }

        private IEnumerable<Gender> _genders { get; set; }

        /*public IEnumerable<Gender> Genders
        {
            get
            {
                var genders = Enum
                    .GetValues(Gender.GetType())
                    .Cast<Gender>();

                return genders;
            }
            set
            {
                _genders = value;
            }
        }
        */
    }
}
