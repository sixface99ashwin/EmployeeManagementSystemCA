using EmployeeManagementSystemCA.Models;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystemCA.DTO
{
    public class UpdateEmployeeDto
    {
       
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }    
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string Gender { get; set; }
        public int PhoneNumber { get; set; }
        public int Salary { get; set; }
        public virtual string DesignationName { get; set; }

    }
}
