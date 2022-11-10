using EmployeeManagementSystemCA.Core.IRepository;
using EmployeeManagementSystemCA.DTO;
using EmployeeManagementSystemCA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace EmployeeManagementSystemCA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentRuleController : ControllerBase
    {
        private readonly IPaymentRule _paymentRule;
        public PaymentRuleController(IPaymentRule paymentRule)
        {
            _paymentRule = paymentRule;
        }
        [HttpGet("GetAllRules")]
        public async Task<IActionResult> GetAllRules()
        {
            try
            {
                var paymentRules = await _paymentRule.GetAllRules();
                if (paymentRules != null)
                {
                    return Ok(paymentRules);
                }
                else
                {
                    return BadRequest("No Payment Rules are available");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetPaymentRuleById/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                if (Id >= 0)
                {
                    var paymentRule = await _paymentRule.GetById(Id);
                    if (paymentRule != null)
                    {
                        return Ok(paymentRule);
                    }
                    else
                    {
                        return BadRequest("No Payment Rules available at these Id");
                    }
                }
                else
                {
                    return BadRequest("Please enter valid Id");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("AddPaymentRule")]
        public async Task<IActionResult> AddPaymentRule(PaymentRuleDto paymentRuleDto)
        {
            try
            {
                if (paymentRuleDto != null)
                {
                    var paymentRule = await _paymentRule.AddPaymentRule(paymentRuleDto);
                    if (paymentRule != null)
                    {
                        return Ok(paymentRule);
                    }
                    else
                    {
                        return BadRequest("Unable to add Payment Rule details");
                    }
                }
                else
                {
                    return BadRequest("Please enter a valid data");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("UpdatePaymentRule/{Id}")]
        public async Task<IActionResult> UpdatePaymentRule(int Id, UpdatePaymentRuleDto updatePaymentRuleDto)
        {
            try
            {
                if (updatePaymentRuleDto != null)
                {
                    var paymentRule = await _paymentRule.UpdatePaymentRule(Id, updatePaymentRuleDto);
                    if (paymentRule != null)
                    {
                        return Ok(paymentRule);
                    }
                    else
                    {
                        return BadRequest("Unable to Update Payment Rule Details");
                    }
                }
                else
                {
                    return BadRequest("Please enter a valid data");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("DeletepaymentRule/{Id}")]
        public async Task<IActionResult> DeletepaymentRule(int Id)
        {
            try
            {
                if (Id >= 0)
                {
                    var paymentRule = await _paymentRule.DeletepaymentRule(Id);
                    if (paymentRule != null)
                    {
                        return Ok(paymentRule);
                    }
                    else
                    {
                        return BadRequest("Unable to Delete Payment Rule Details");
                    }
                }
                else
                {
                    return BadRequest("Please Enter valid Id");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

