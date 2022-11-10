using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystemCA.DTO
{
    public class UpdatePaymentRuleDto
    {
        [Required(ErrorMessage = "Please enter your  policy")]
       
        public string Policy { get; set; }

        [Required(ErrorMessage = "Please enter your  policy details")]
        
        public string PolicyDetails { get; set; }
    }
}
