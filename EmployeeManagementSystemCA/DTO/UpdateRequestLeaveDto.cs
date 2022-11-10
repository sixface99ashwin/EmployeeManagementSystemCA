using EmployeeManagementSystemCA.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystemCA.DTO
{
    public class UpdateRequestLeaveDto
    {
        [Required(ErrorMessage = "Please enter your type of Leave")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string LeaveType { get; set; }

       
        public DateTime FromDate { get; set; }

        
        public DateTime ToDate { get; set; }

        [StringLength(50)]
        [DataType(DataType.Text)]
        public virtual string EmpId { get; set; }
    }
}
