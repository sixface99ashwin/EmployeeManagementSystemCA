using EmployeeManagementSystemCA.DTO;
using System.Threading.Tasks;

namespace EmployeeManagementSystemCA.Core.IRepository
{
    public interface IWorkingHour
    {
        Task<WorkingHourDto[]> GetAllDetails();
        Task<WorkingHourDto> GetById(int id);
        Task<WorkingHourDto> AddWorkingDetails(WorkingHourDto workingHourDto);
        Task<WorkingHourDto> UpdateWorkingDetails(int Id, UpdateWorkingHourDto updateWorkingHourDto);
        Task<WorkingHourDto> DeleteWorkingDetails(int Id);
    }
}
