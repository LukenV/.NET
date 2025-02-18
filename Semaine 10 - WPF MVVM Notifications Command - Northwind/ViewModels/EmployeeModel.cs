﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class EmployeeModel : INotifyPropertyChanged
    {
        private readonly Employee _employee;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public EmployeeModel(Employee employee)
        {
            _employee = employee;
        }

        public Employee Employee
        {
            get { return _employee; }
        }

        public string FullName { get { return _employee.FirstName + " " + _employee.LastName; } }
        public string FirstName { get { return _employee.FirstName; ; } set { _employee.FirstName = value; OnPropertyChanged("FullName"); } }
        public string LastName { get { return _employee.LastName; } set { _employee.LastName = value; OnPropertyChanged("FullName"); } }
        public string DisplayBirthDate { get 
            { 
                if (_employee.BirthDate.HasValue)
                {
                    return _employee.BirthDate.Value.ToShortDateString();
                }
                return ""; 
            } }
        public DateTime? BirthDate { get { return _employee.BirthDate; } set { _employee.BirthDate = value; OnPropertyChanged("DisplayBirthDate"); } }
        public DateTime? HireDate { get { return _employee.HireDate; } set { _employee.HireDate = value; } }
        public string? TitleOfCourtesy { get { return _employee.TitleOfCourtesy; } set { _employee.TitleOfCourtesy = value; } }
    }
}
