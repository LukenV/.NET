using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class EmployeeModel
    {
        private readonly Employee _employee;
        private readonly string _fullName;
        private string _firstName;
        private string _lastName;
        private readonly string _displayBirthDate;
        private DateTime? _birthDate;
        private DateTime? _hireDate;
        private string? _titleOfCourtesy;

        public EmployeeModel(Employee employee)
        {
            _employee = employee;
            _fullName = employee.FirstName + " " + employee.LastName;
            _firstName = employee.FirstName;
            _lastName = employee.LastName;
            string formattedBirthDate = "";
            if (employee.BirthDate != null)
            {
                formattedBirthDate = employee.BirthDate.Value.Year + "/" + employee.BirthDate.Value.Month + "/" + employee.BirthDate.Value.Day;
            } else
            {
                formattedBirthDate = "00/00/0000";
            }
            _displayBirthDate = formattedBirthDate;
            _birthDate = employee.BirthDate;
            _hireDate = employee.HireDate;
            _titleOfCourtesy = employee.TitleOfCourtesy;
        }

        public string FullName { get { return _fullName; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string DisplayBirthDate { get { return _displayBirthDate; } }
        public DateTime? BirthDate { get { return _birthDate; } set { _birthDate = value; } }
        public DateTime? HireDate { get { return _hireDate; } set { _hireDate = value; } }
        public string? TitleOfCourtesy { get { return _titleOfCourtesy; } set { _titleOfCourtesy = value; } }
    }
}
