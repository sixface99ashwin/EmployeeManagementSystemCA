using AutoMapper;
using EmployeeManagementSystemCA.Core.IRepository;
using EmployeeManagementSystemCA.CustomException;
using EmployeeManagementSystemCA.Data;
using EmployeeManagementSystemCA.DTO;
using EmployeeManagementSystemCA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeManagementSystemCA.Core.Repository
{
    public class DesignationRepository : IDesignation
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly IMapper _mapper;
        public DesignationRepository(EmployeeDbContext dbContext,IMapper mapper)
        {
            _dbContext=dbContext;
            _mapper = mapper;
        }
        public async Task<DesignationDto> AddDesignationDetails(DesignationDto designationdto)
        {
            try
            {
                var record = _dbContext.Designations.FirstOrDefault(x => x.DesignationName == designationdto.DesignationName);
                if (record == null)
                {
                    _dbContext.Designations.Add(_mapper.Map<Designation>(designationdto));
                    await _dbContext.SaveChangesAsync();
                    return designationdto;
                }
                else
                {
                    throw new InvalidOperationException("Data Already present in the table");
                }
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
        }

        public async Task<Designation> DeleteDesignationDetails(string Name)
        {
            try
            {
                var designation = await _dbContext.Designations.FirstOrDefaultAsync(x => x.DesignationName.Equals(Name));
                if (designation != null)
                {
                    _dbContext.Designations.Remove(designation);
                    _dbContext.SaveChanges();
                    return designation;
                }
                else
                {
                    throw new IdNotFoundException("Id is not present in database");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }

        }

        public async Task<DesignationDto[]> GetAllDesignationData()
        {
            try
            {
                var designation = _mapper.Map<DesignationDto[]>(await _dbContext.Designations.ToListAsync());
                if (designation != null)
                {
                    return designation;
                }
                else
                {
                    throw new DatabaseException("Unable to connect database");
                }
            }
            catch (DatabaseException e)
            {
                throw e;
            }
        }

        public async Task<DesignationDto> GetDesignationByName(string Name)
        {
            try
            {
                var designation = _mapper.Map<DesignationDto>(await _dbContext.Designations.FirstOrDefaultAsync(x => x.DesignationName == Name));
                if (designation != null)
                {
                    return designation;
                }
                else
                {
                    throw new IdNotFoundException("No Records at this Name Not");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }

        }

        public async Task<DesignationDto> UpdateDesignationDetails(string Name, UpdateDesignationDto updatedesignationDto)
        {
            try
            {

                var designation = await _dbContext.Designations.FirstOrDefaultAsync(x => x.DesignationName == Name);

                if (designation != null)
                {
                    
                    designation.DesignationName = Name;
                    designation.RoleName= updatedesignationDto.RoleName;
                    designation.DepartmentName = updatedesignationDto.DepartmentName;
                    await _dbContext.SaveChangesAsync();
                    return _mapper.Map<DesignationDto>(designation);
                }
                else
                {
                    throw new InvalidOperationException("Data Already present in Database");
                }
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
        }
    }
}
