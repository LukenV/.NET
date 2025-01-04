using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class EmployeeViewModel
    {
        private List<EmployeeModel> _employeesList;
        private List<string?> _titlesList;
        private NorthwindContext context = new NorthwindContext();

        public List<EmployeeModel> EmployeesList
        {
            get { return _employeesList = _employeesList ?? loadEmployees(); }
        }

        private List<EmployeeModel> loadEmployees()
        {
            List<EmployeeModel> localCollection = new List<EmployeeModel>();
            foreach (var item in context.Employees)
            {
                localCollection.Add(new EmployeeModel(item));
            }
            return localCollection;
        }

        public List<string?> ListTitle
        {
            get { return _titlesList = _titlesList ?? loadTitleOfCourtesy(); }
        }

        private List<string?> loadTitleOfCourtesy()
        {
            return context.Employees.Select(e => e.TitleOfCourtesy).Distinct().ToList();
        }

    }
}
