using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.DTO.Employee
{
    public  class EmployeeDetailsReturnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public string? Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly HiringDate { get; set; }
        public string ?gender { get; set; }
        [Display(Name = "EmployeeType")]
        public string ?EmployeeType { get; set; }

        public string? Department { get; set; }

        public int createdbt { get; set; }
        public DateTime createdon { get; set; }
        public int LastModifiedby { get; set; }
        public DateTime LastModifiedat { get; set; }
        public bool IsDeleted { get; set; }
    }
}
