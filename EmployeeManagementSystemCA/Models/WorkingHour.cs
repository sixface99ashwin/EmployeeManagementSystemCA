using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystemCA.Models
{
    public class WorkingHour
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string Month { get; set; }
        public int CompanyWorkingHour { get; set; }
        public int EmployeeWorkingHour { get; set; }
        
    }
}
