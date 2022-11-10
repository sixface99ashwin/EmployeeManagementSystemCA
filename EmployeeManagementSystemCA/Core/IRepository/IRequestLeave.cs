using EmployeeManagementSystemCA.DTO;
using System.Threading.Tasks;

namespace EmployeeManagementSystemCA.Core.IRepository
{
    public interface IRequestLeave
    {
        Task<RequestLeaveDto[]> GetAllRequestLeave();
        Task<RequestLeaveDto> GetById(int id);
        Task<RequestLeaveDto> AddRequestLeave(RequestLeaveDto requestLeaveDto);
        Task<RequestLeaveDto> UpdateRequestleave(int Id, UpdateRequestLeaveDto updateRequestLeaveDto);
        Task<RequestLeaveDto> DeleteRequestLeave(int Id);
    }
}
