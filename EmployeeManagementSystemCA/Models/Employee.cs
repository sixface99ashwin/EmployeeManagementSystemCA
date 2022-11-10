using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystemCA.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Gender { get; set; }
        //public DateTime DOB { get; set; }
        public string ImageUrl { get; set; }
        public int Salary { get; set; }
        public string DesignationName { get; set; }
        [ForeignKey("DesignationName")]
        public Designation Designations { get; set; }

    }
}
