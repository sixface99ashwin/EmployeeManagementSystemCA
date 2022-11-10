using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystemCA.Models
{
    public class PaymentRule
    {
        [Key]
        [Required]
        public int RuleId { get; set; }
        public string Policy { get; set; }
        public string PolicyDetails { get; set; }
    }
}
