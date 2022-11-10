using AutoMapper;
using EmployeeManagementSystemCA.Core.IRepository;
using EmployeeManagementSystemCA.CustomException;
using EmployeeManagementSystemCA.Data;
using EmployeeManagementSystemCA.DTO;
using EmployeeManagementSystemCA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeManagementSystemCA.Core.Repository
{
    public class PaymentRuleRepository : IPaymentRule
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly IMapper _mapper;
        public PaymentRuleRepository(EmployeeDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PaymentRuleDto> AddPaymentRule(PaymentRuleDto paymentRuleDto)
        {
            try
            {
                _dbContext.PaymentRules.Add(_mapper.Map<PaymentRule>(paymentRuleDto));
                await _dbContext.SaveChangesAsync();
                return paymentRuleDto;
            }
            catch 
            {
                throw new DatabaseException("Unable to connect Database");
            }
        }

        public async Task<PaymentRuleDto> DeletepaymentRule(int Id)
        {
            try
            {
                var paymentRule = await _dbContext.PaymentRules.FirstOrDefaultAsync(x => x.RuleId == Id);
                if (paymentRule != null)
                {
                    _dbContext.PaymentRules.Remove(paymentRule);
                    _dbContext.SaveChanges();
                    return _mapper.Map < PaymentRuleDto >(paymentRule);
                }
                else
                {
                    throw new IdNotFoundException("No Records available at these Id");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }
        }

        public async Task<PaymentRuleDto[]> GetAllRules()
        {
            try
            {
                var paymentRule = _mapper.Map<PaymentRuleDto[]>(await _dbContext.PaymentRules.ToListAsync());
                if (paymentRule != null)
                {
                    return paymentRule;
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

        public async Task<PaymentRuleDto> GetById(int Id)
        {
            try
            {
                var paymentRule = _mapper.Map<PaymentRuleDto>(await _dbContext.PaymentRules.FirstOrDefaultAsync(x => x.RuleId == Id));
                if (paymentRule != null)
                {
                    return paymentRule;
                }
                else
                {
                    throw new IdNotFoundException("No Records Found at this Id");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }
        }

        public async Task<PaymentRuleDto> UpdatePaymentRule(int Id, UpdatePaymentRuleDto updatePaymentRuleDto)
        {
            try
            {

                var paymentRule = await _dbContext.PaymentRules.FirstOrDefaultAsync(x => x.RuleId == Id);

                if (paymentRule != null)
                {
                    
                    paymentRule.RuleId = Id;
                    paymentRule.Policy = updatePaymentRuleDto.Policy;
                    paymentRule.PolicyDetails = updatePaymentRuleDto.PolicyDetails;
                    await _dbContext.SaveChangesAsync();
                    return _mapper.Map<PaymentRuleDto>(paymentRule);
                }
                else
                {
                    throw new IdNotFoundException("No Records Found at this Id");
                }
            }
            catch (IdNotFoundException e)
            {
                throw e;
            }
        }
    }
}
