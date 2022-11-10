using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystemCA.DTO
{
    public class UserRegisterDto
    {
        
        [Required(ErrorMessage = "Please enter Email")]
        
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        
        
        [Required]
        public string FirstName { get; set; }

        
        [Required]
        public string Lastname { get; set; }
        public string Password { get; set; }
    }
}
