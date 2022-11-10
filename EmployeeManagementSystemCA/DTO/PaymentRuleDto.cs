using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystemCA.DTO
{
    public class PaymentRuleDto
    {
        [Required]
        public int RuleId { get; set; }

        [Required(ErrorMessage = "Please enter your  policy")]
        public string Policy { get; set; }

        [Required(ErrorMessage = "Please enter your  policy details")]
       
        public string PolicyDetails { get; set; }
    }
}
