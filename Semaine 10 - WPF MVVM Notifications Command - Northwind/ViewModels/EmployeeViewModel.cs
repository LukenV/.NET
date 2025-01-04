using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class EmployeeViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<EmployeeModel> _employeesList;
        private List<string?> _titlesList;
        private ObservableCollection<OrderModel> _odersList;
        private NorthwindContext context = new NorthwindContext();
        private EmployeeModel _selectedEmployee;

        private DelegateCommand _addCommand;
        private DelegateCommand _saveCommand;

        public event PropertyChangedEventHandler PropertyChanged; // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // On notifie que la propriété a changé
            }
        }

        public EmployeeModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { _selectedEmployee = value; OnPropertyChanged("OrdersList"); }
        }

        public ObservableCollection<EmployeeModel> EmployeesList
        {
            get { return _employeesList = _employeesList ?? loadEmployees(); }
        }

        public ObservableCollection<OrderModel> OrdersList
        {
            get {
                if (SelectedEmployee != null)
                {
                    _odersList = loadOrders();
                }
                return _odersList;
            }
        }

        private ObservableCollection<EmployeeModel> loadEmployees()
        {
            ObservableCollection<EmployeeModel> localCollection = new ObservableCollection<EmployeeModel>();
            foreach (var item in context.Employees)
            {
                localCollection.Add(new EmployeeModel(item));
            }
            return localCollection;
        }

        private ObservableCollection<OrderModel> loadOrders()
        {
            ObservableCollection<OrderModel> localCollection = new ObservableCollection<OrderModel>();

            var employeeOrders = context.Orders.Where(o => o.EmployeeId == SelectedEmployee.Employee.EmployeeId).OrderByDescending(o => o.OrderDate).ToList();

            if (employeeOrders.Count == 0) return localCollection;

            for (int i=0; i<3; i++)
            {
                Order currentOrder = employeeOrders[i];
                decimal total = context.OrderDetails.Where(od => od.OrderId == currentOrder.OrderId).Sum(od => od.UnitPrice);
                localCollection.Add(new OrderModel(currentOrder, total));
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

        public DelegateCommand SaveCommand
        {
            get { return _saveCommand = _saveCommand ?? new DelegateCommand(UpdateEmployee); }
        }

        public DelegateCommand AddCommand
        {
            get { return _addCommand = _addCommand ?? new DelegateCommand(AddEmployee); }
        }

        private void UpdateEmployee()
        {
            Employee? employeeFound = context.Employees.Where(e => e.EmployeeId == SelectedEmployee.Employee.EmployeeId).FirstOrDefault();

            if (employeeFound == null)
            {
                context.Employees.Add(SelectedEmployee.Employee);
            }
            
            context.SaveChanges();

            MessageBox.Show("Update successful !");
        }

        private void AddEmployee()
        {
            Employee employee = new Employee();
            EmployeeModel employeeModel = new EmployeeModel(employee);
            EmployeesList.Add(employeeModel);
            SelectedEmployee = employeeModel;

            MessageBox.Show("New employee added !");
        }

    }
}
