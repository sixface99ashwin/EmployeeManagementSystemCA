using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystemCA.DTO
{
    public class UpdateDesignationDto
    {
        [Required(ErrorMessage = "please enter your RoleName")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "please enter your DepartmentName")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string DepartmentName { get; set; }
    }
}
