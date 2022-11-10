using AutoMapper;
using EmployeeManagementSystemCA.DTO;
using EmployeeManagementSystemCA.Models;

namespace EmployeeManagementSystemCA.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<UpdateEmployeeDto, Employee>().ReverseMap();
            CreateMap<Designation,DesignationDto >().ReverseMap();
            CreateMap<UpdateDesignationDto,Designation>().ReverseMap();
            CreateMap<PaymentRule, PaymentRuleDto>().ReverseMap();
            CreateMap<UpdatePaymentRuleDto,PaymentRule>().ReverseMap();
            CreateMap<RequestLeave, RequestLeaveDto>().ReverseMap();
            CreateMap<UpdateRequestLeaveDto, RequestLeave>().ReverseMap();
            CreateMap<WorkingHour, WorkingHourDto>().ReverseMap();
            CreateMap<UpdateWorkingHourDto, WorkingHour>().ReverseMap();
        }
    }
}
