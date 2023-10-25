using EmployeesManager.Models;
using EmployeesManager.Models.DTO;
using EmployeesManager.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManager.Helpers
{
    public static class Mappings
    {
        public static void MapEmployeesFromDTO(EmployeeDTO source, Employee destination)
        {
            destination.Id = source.Id;
            destination.Status = (StatusEnum.EmployeeStatus)Enum.Parse(typeof(StatusEnum.EmployeeStatus), source.Status);
            destination.Email = source.Email;
            destination.Name = source.Name;
            destination.Gender = (GenderEnum.Gender)Enum.Parse(typeof(GenderEnum.Gender), source.Gender);
        }
    }
}
