using EmployeesManager.Abstractions;
using EmployeesManager.Commands;
using EmployeesManager.Models.DTO;
using EmployeesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static EmployeesManager.Models.Enums.GenderEnum;
using static EmployeesManager.Models.Enums.StatusEnum;
using EmployeesManager.Services.Interfaces;
using EmployeesManager.Helpers;
using System.Windows;

namespace EmployeesManager.ViewModels
{
    public class CreateEmployeeViewModel : BaseNotifyPropertyChanged
    {
        private readonly IEmployeesService _employeesService;
        private readonly Mapper _mapper;

        public CreateEmployeeViewModel(IEmployeesService employeesService, Mapper mapper)
        {
            _employeesService = employeesService;
            _mapper = mapper;
        }

        #region PrivateProperties

        private string _name { get; set; }



        private string _email { get; set; }


        private Gender _gender { get; set; }

        

        private EmployeeStatus _status { get; set; }

        private IEnumerable<Gender> _genders { get; set; }
        
        #endregion Properties

        #region PublicProperties

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }


        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public Gender Gender
        {
            get
            {
                return _gender;
            }

            set
            {
                _gender = value;
            }
        }

        public EmployeeStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public IEnumerable<EmployeeStatus> Statuses
        {
            get
            {
                var statuses = Enum
                    .GetValues(Status.GetType())
                    .Cast<EmployeeStatus>();

                return statuses;
            }
            set { }
        }

        public IEnumerable<Gender> Genders
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

        #endregion PublicProperties

        #region Commands
        public CreateEmployeeCommand CreateCommand => new CreateEmployeeCommand(_employeesService, _mapper, this);
        #endregion Commands
    }
}
