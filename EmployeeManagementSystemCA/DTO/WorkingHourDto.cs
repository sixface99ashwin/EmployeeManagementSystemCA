using EmployeeManagementSystemCA.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace EmployeeManagementSystemCA.DTO
{
    public class WorkingHourDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Month { get; set; }

        [Required(ErrorMessage = "Please enter your Company Working Hour")]
        
        public int CompanyWorkingHour { get; set; }


        [Required(ErrorMessage = "Please enter your Employee Working Hour")]
      
        public int EmployeeWorkingHour { get; set; }


        [Required(ErrorMessage = "Please enter your Employee Id")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public virtual string EmpId { get; set; }
    }
}
