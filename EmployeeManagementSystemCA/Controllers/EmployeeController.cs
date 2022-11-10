using EmployeeManagementSystemCA.Core.IRepository;
using EmployeeManagementSystemCA.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeeManagementSystemCA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees= await _employee.GetAllEmployees();
                if (employees != null)
                {
                    return Ok(employees);
                }
                else
                {
                    return BadRequest("No Employees available");
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetEmployeeById/{Id}")]
        public async Task<IActionResult> GetEmployeeById(string Id)
        {
            try
            {
                if (Id != null)
                {
                    var employee = await _employee.GetEmployeeById(Id);
                    if (employee != null)
                    {
                        return Ok(employee);
                    }
                    else
                    {
                        return BadRequest("No Employee available at these Id");
                    }
                }
                else
                {
                    return BadRequest("Please Enter valid Id");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetEmployeeByName/{Name}")]
        public async Task<IActionResult> GetEmployeeByName(string Name)
        {
            try
            {
                if (Name != null)
                {
                    var employee = await _employee.GetEmployeeByName(Name);
                    if (employee != null)
                    {
                        return Ok(employee);
                    }
                    else
                    {
                        return BadRequest("No Employee available at these Name");
                    }
                }
                else
                {
                    return BadRequest("Please enter valid Name");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee(EmployeeDto employeeDto)
        {
            try
            {
                if (employeeDto != null)
                {
                    var employee = await _employee.AddEmployee(employeeDto);
                    if (employee != null)
                    {
                        return Ok(employee);
                    }
                    else
                    {
                        return BadRequest("Unable to add Employee details");
                    }
                }
                else
                {
                    return BadRequest("Please enter a valid data");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("UpdateEmployee/{Id}")]
        public async Task<IActionResult> UpdateEmployee(string Id,UpdateEmployeeDto updateemployeeDto)
        {
            try
            {
                if (updateemployeeDto != null)
                {
                    var employee = await _employee.UpdateEmployee(Id,updateemployeeDto);
                    if (employee != null)
                    {
                        return Ok(employee);
                    }
                    else
                    {
                        return BadRequest("Unable to Update Employee Details");
                    }
                }
                else
                {
                    return BadRequest("Please enter a valid data");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("DeleteEmployee/{Id}")]
        public async Task<IActionResult> DeleteEmployee(string Id)
        {
            try
            {
                if (Id != null)
                {
                    var employee = await _employee.DeleteEmployee(Id);
                    if (employee != null)
                    {
                        return Ok(employee);
                    }
                    else
                    {
                        return BadRequest("Unable to Delete Employee Details");
                    }
                }
                else
                {
                    return BadRequest("Please Enter valid Id");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
