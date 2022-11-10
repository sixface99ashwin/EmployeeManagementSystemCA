using System.ComponentModel.DataAnnotations;
using System;
using EmployeeManagementSystemCA.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystemCA.DTO
{
    public class RequestLeaveDto
    {
        [Required]
        public int RequestId { get; set; }

        [Required(ErrorMessage = "Please enter your type of Leave")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string LeaveType { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }

        [StringLength(50)]
        [DataType(DataType.Text)]
        public virtual string EmpId { get; set; }
        
     


        


    }
}
