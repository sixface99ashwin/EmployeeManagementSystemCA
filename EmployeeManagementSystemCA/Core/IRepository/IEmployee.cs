using EmployeeManagementSystemCA.DTO;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystemCA.Core.IRepository
{
    public interface IEmployee
    {
        Task<EmployeeDto[]> GetAllEmployees();
        Task<EmployeeDto> GetEmployeeById(string Id);

        Task<EmployeeDto> GetEmployeeByName(string Name);
        Task<EmployeeDto> AddEmployee(EmployeeDto addEmployeeDto);
        
        Task<EmployeeDto> UpdateEmployee(string Id,UpdateEmployeeDto updateEmployeeDto);
        Task<EmployeeDto> DeleteEmployee(string Id);
        Task<int> CountEmployee();
    }
}
