using EmployeeManagementSystemCA.DTO;
using EmployeeManagementSystemCA.Models;
using System.Threading.Tasks;

namespace EmployeeManagementSystemCA.Core.IRepository
{
    public interface IDesignation
    {
        Task<DesignationDto[]> GetAllDesignationData();

        Task<DesignationDto> GetDesignationByName(string Name);
        Task<DesignationDto> AddDesignationDetails(DesignationDto designationdto);
        Task<DesignationDto> UpdateDesignationDetails(string Name,UpdateDesignationDto updatedesignation);
        Task<Designation> DeleteDesignationDetails(string Name);

    }
}
