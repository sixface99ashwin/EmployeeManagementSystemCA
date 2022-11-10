using AutoMapper;
using EmployeeManagementSystemCA.Core.IRepository;
using EmployeeManagementSystemCA.CustomException;
using EmployeeManagementSystemCA.Data;
using EmployeeManagementSystemCA.DTO;
using EmployeeManagementSystemCA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystemCA.Core.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly IMapper _mapper;
        public EmployeeRepository(EmployeeDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> AddEmployee(EmployeeDto addEmployeeDto)
        {
            try
            {
                var emp = _dbContext.Employees.FirstOrDefault(x => x.EmpId == addEmployeeDto.EmpId);
                if (emp == null)
                {
                    _dbContext.Employees.Add(_mapper.Map<Employee>(addEmployeeDto));
                    await _dbContext.SaveChangesAsync();
                    return addEmployeeDto;
                }
                else
                {
                    throw new InvalidOperationException("Data already present in database");
                }
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
        }

        public async Task<int> CountEmployee()
        {
            var count =  (await _dbContext.Employees.ToListAsync()).Count;
            return count;
        }

        public async Task<EmployeeDto> DeleteEmployee(string Id)
        {
            try
            {
                var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.EmpId == Id);
                if(employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                    _dbContext.SaveChanges();
                    return (_mapper.Map<EmployeeDto>(employee));
                }
                else
                {
                     throw new IdNotFoundException("Invalid Id");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }
        }

        public async Task<EmployeeDto[]> GetAllEmployees()
        {
            try
            {
                EmployeeDto[] employees = _mapper.Map<EmployeeDto[]>(await _dbContext.Employees.Include(x => x.Designations).ToListAsync());
                if (employees != null)
                {
                    return employees;
                }
                else
                {
                    throw new IdNotFoundException("No Records Found");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }
        }

        public async Task<EmployeeDto> GetEmployeeById(string Id)
        {
            try
            {
                var employee= _mapper.Map<EmployeeDto>(await _dbContext.Employees.Include(x => x.Designations).FirstOrDefaultAsync(x => x.EmpId == Id));
                if(employee != null)
                {
                    return employee;
                }
                else 
                {
                    throw new IdNotFoundException("No Records Found at these Id");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }
        }

        public async Task<EmployeeDto> GetEmployeeByName(string Name)
        {
            try
            {
                var employee = _mapper.Map<EmployeeDto>(await _dbContext.Employees.Include(x => x.Designations).FirstOrDefaultAsync(x => x.FirstName == Name));
                if (employee != null)
                {
                    return employee;
                }
                else
                {
                    throw new IdNotFoundException("No Records Found at these Name");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }

        }

        public async Task<EmployeeDto> UpdateEmployee(string Id,UpdateEmployeeDto updateEmployeeDto)
        {
            try
            {
                
                var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.EmpId == Id);

                if (employee != null)
                {
                    
                    employee.EmpId = Id;
                    employee.FirstName = updateEmployeeDto.Firstname;
                    employee.LastName = updateEmployeeDto.LastName;
                    employee.Email = updateEmployeeDto.Email;
                    employee.Address = updateEmployeeDto.Address;
                    employee.Gender=updateEmployeeDto.Gender;
                    employee.ImageUrl = updateEmployeeDto.ImageUrl;
                    employee.PhoneNumber= updateEmployeeDto.PhoneNumber;
                    employee.Salary = updateEmployeeDto.Salary;
                    employee.DesignationName = updateEmployeeDto.DesignationName;
                    await _dbContext.SaveChangesAsync();
                    return _mapper.Map<EmployeeDto>(employee);
                }
                else
                {
                    throw new InvalidOperationException("Data already present in database");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
