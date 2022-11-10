using EmployeeManagementSystemCA.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;
using System;

namespace EmployeeManagementSystemCA.DTO
{
    public class EmployeeDto
    {

        [StringLength(50)]
        [DataType(DataType.Text)]
        public string EmpId { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string Gender { get; set; }

       


        
        public int PhoneNumber { get; set; }

        
        public int Salary { get; set; }

      
        public virtual string DesignationName { get; set; }
        public virtual DesignationDto Designations { get; set; }
    }
}
