using EmployeeManagementSystemCA.DTO;
using System.Threading.Tasks;

namespace EmployeeManagementSystemCA.Core.IRepository
{
    public interface IPaymentRule
    {
        Task<PaymentRuleDto[]> GetAllRules();
        Task<PaymentRuleDto> GetById(int id);
        Task<PaymentRuleDto> AddPaymentRule(PaymentRuleDto paymentRuleDto);
        Task<PaymentRuleDto> UpdatePaymentRule(int Id,UpdatePaymentRuleDto updatePaymentRuleDto);
        Task<PaymentRuleDto> DeletepaymentRule(int Id);
    }
}
