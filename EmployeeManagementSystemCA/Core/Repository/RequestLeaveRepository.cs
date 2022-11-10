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
    public class RequestLeaveRepository:IRequestLeave
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly IMapper _mapper;
        public RequestLeaveRepository(EmployeeDbContext dbContext, IMapper mapper )
        {
            _dbContext = dbContext;
            _mapper = mapper;
                 
        }

        public async Task<RequestLeaveDto> AddRequestLeave(RequestLeaveDto requestLeaveDto)
        {
            try
            {
                _dbContext.RequestLeaves.Add(_mapper.Map<RequestLeave>(requestLeaveDto));
                await _dbContext.SaveChangesAsync();
                return requestLeaveDto;
            }
            catch (DatabaseException )
            {
                throw new DatabaseException("Unable to connect database");
            }
        }

        public async Task<RequestLeaveDto> DeleteRequestLeave(int Id)
        {
            try
            {
                var requestLeave = await _dbContext.RequestLeaves.FirstOrDefaultAsync(x => x.RequestId == Id);
                if (requestLeave != null)
                {
                    _dbContext.RequestLeaves.Remove(requestLeave);
                    _dbContext.SaveChanges();
                    return _mapper.Map < RequestLeaveDto > (requestLeave);
                }
                else
                {
                    throw new IdNotFoundException("No record Found at this Id");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }
        }

        public async Task<RequestLeaveDto[]> GetAllRequestLeave()
        {
            try
            {
                var requestleave = _mapper.Map<RequestLeaveDto[]>(await _dbContext.RequestLeaves.ToListAsync());
                if (requestleave != null)
                {
                    return requestleave;
                }
                else
                {
                    throw new IdNotFoundException("No record Found at this Id");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }
        }

        public async Task<RequestLeaveDto> GetById(int Id)
        {
            try
            {
                var requestleave = _mapper.Map<RequestLeaveDto>(await _dbContext.RequestLeaves.FirstOrDefaultAsync(x => x.RequestId == Id));
                if (requestleave != null)
                {
                    return requestleave;
                }
                else
                {
                    throw new IdNotFoundException("No record Found at this Id");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }
        }

        public async Task<RequestLeaveDto> UpdateRequestleave(int Id, UpdateRequestLeaveDto updateRequestLeaveDto)
        {
            try
            {

                var requestLeave = await _dbContext.RequestLeaves.FirstOrDefaultAsync(x => x.RequestId == Id);

                if (requestLeave != null)
                {
                   
                    requestLeave.RequestId = Id;
                    requestLeave.LeaveType = updateRequestLeaveDto.LeaveType;
                    requestLeave.FromDate = updateRequestLeaveDto.FromDate;
                    requestLeave.ToDate = updateRequestLeaveDto.ToDate;
                    requestLeave.EmpId = updateRequestLeaveDto.EmpId;
                    
                    await _dbContext.SaveChangesAsync();
                    return _mapper.Map<RequestLeaveDto>(requestLeave);
                }
                else
                {
                    throw new IdNotFoundException("No record Found at this Id");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }
        }
    }
}
