using AutoMapper;
using EmployeeManagementSystemCA.Core.IRepository;
using EmployeeManagementSystemCA.CustomException;
using EmployeeManagementSystemCA.Data;
using EmployeeManagementSystemCA.DTO;
using EmployeeManagementSystemCA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EmployeeManagementSystemCA.Core.Repository
{
    public class WorkingHourRepository:IWorkingHour
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly IMapper _mapper;
        public WorkingHourRepository(EmployeeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<WorkingHourDto> AddWorkingDetails(WorkingHourDto workingHourDto)
        {
            try
            {
                _dbContext.WorkingHours.Add(_mapper.Map<WorkingHour>(workingHourDto));
                await _dbContext.SaveChangesAsync();
                return workingHourDto;
            }
            catch (DatabaseException )
            {
                throw new DatabaseException("Unable to connect Database");
            }
        }

        public async Task<WorkingHourDto> DeleteWorkingDetails(int Id)
        {
            try
            {
                var workingHour = await _dbContext.WorkingHours.FirstOrDefaultAsync(x => x.Id == Id);
                if (workingHour != null)
                {
                    _dbContext.WorkingHours.Remove(workingHour);
                    _dbContext.SaveChanges();
                    return _mapper.Map<WorkingHourDto>(workingHour);
                }
                else
                {
                    throw new IdNotFoundException("No Records found at this Id");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }
        }

        public async Task<WorkingHourDto[]> GetAllDetails()
        {
            try
            {
                var workingHours = _mapper.Map<WorkingHourDto[]>(await _dbContext.WorkingHours.ToListAsync());
                if (workingHours != null)
                {
                    return workingHours;
                }
                else
                {
                    throw new IdNotFoundException("No Record found");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }
        }

        public async Task<WorkingHourDto> GetById(int Id)
        {
            try
            {
                var workingHour = _mapper.Map<WorkingHourDto>(await _dbContext.WorkingHours.FirstOrDefaultAsync(x => x.Id == Id));
                if (workingHour != null)
                {
                    return workingHour;
                }
                else
                {
                    throw new IdNotFoundException("No Record found at this Id");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }
        }

        public async Task<WorkingHourDto> UpdateWorkingDetails(int Id, UpdateWorkingHourDto updateWorkingHourDto)
        {
            try
            {

                var workingHour = await _dbContext.WorkingHours.FirstOrDefaultAsync(x => x.Id == Id);

                if (workingHour != null)
                {
                    
                    workingHour.Id = Id;
                    workingHour.EmpId = updateWorkingHourDto.EmpId;
                    workingHour.Month = updateWorkingHourDto.Month;
                    workingHour.CompanyWorkingHour=updateWorkingHourDto.CompanyWorkingHour;
                    workingHour.EmployeeWorkingHour=updateWorkingHourDto.EmployeeWorkingHour;
                    await _dbContext.SaveChangesAsync();
                    return _mapper.Map<WorkingHourDto>(workingHour);
                }
                else
                {
                    throw new IdNotFoundException("No Record found at this Id");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }
        }
    }
}
