using Microsoft.AspNetCore.Mvc;
using Semaine_7___Recap_async_await___Northwind_API.Entities;
using Semaine_7___Recap_async_await___Northwind_API.Models;
using Semaine_7___Recap_async_await___Northwind_API.UnitsOfWork;

namespace Semaine_7___Recap_async_await___Northwind_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly NorthwindContext _northwindContext;
        private readonly UnitOfWorkNorthwindSQL _unitOfWorkSQL;

        public EmployeesController()
        {
            _northwindContext = new NorthwindContext();
            _unitOfWorkSQL = new UnitOfWorkNorthwindSQL(_northwindContext);
        }

        [HttpGet]
        public async Task<IList<EmployeeDTO>> GetAllEmployees()
        {
            IList<Employee> employees = await _unitOfWorkSQL.EmployeesRepository.GetAllAsync();
            return employees.Select(e=> EmployeeToEmployeeDTO(e)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<EmployeeDTO?> GetOneEmployee(int id)
        {
            IList<Employee> employees = await _unitOfWorkSQL.EmployeesRepository.SearchForAsync(o => o.EmployeeId == id);
            EmployeeDTO? employeeFound = employees.Select(o => EmployeeToEmployeeDTO(o)).FirstOrDefault();
            return employeeFound;
        }

        [HttpPost]
        public async void CreateOneEmployee(EmployeeDTO employeeDTO)
        {
            employeeDTO.EmployeeId = 0;
            Employee employee = EmployeeDTOToEmployee(employeeDTO);

            await _unitOfWorkSQL.EmployeesRepository.InsertAsync(employee);
        }

        [HttpPut]
        public async Task UpdateOneEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = EmployeeDTOToEmployee(employeeDTO);
            await _unitOfWorkSQL.EmployeesRepository.SaveAsync(employee);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteOneEmployee(int id)
        {
            IList<Employee> employees = await _unitOfWorkSQL.EmployeesRepository.SearchForAsync(e => e.EmployeeId == id);
            Employee? employeeFound = employees.FirstOrDefault();

            if (employeeFound == null) return false;

            await _unitOfWorkSQL.EmployeesRepository.DeleteAsync(employeeFound);

            return true;
        }

        private static Employee EmployeeDTOToEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = new Employee
            {
                EmployeeId = employeeDTO.EmployeeId,
                LastName = employeeDTO.LastName,
                FirstName = employeeDTO.FirstName,
                BirthDate = employeeDTO.BirthDate,
                HireDate = employeeDTO.HireDate,
                Title = employeeDTO.Title,
                TitleOfCourtesy = employeeDTO.TitleOfCourtesy
            };

            return employee;
        }

        private static EmployeeDTO EmployeeToEmployeeDTO(Employee employee)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy

            };

            return employeeDTO;
        }
    }
}
