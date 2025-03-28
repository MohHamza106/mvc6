using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.DTO.Employee
{
    public class EmployeeToReturnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string ?gender { get; set; }
        public string ?EmployeeType { get; set; }

        public string? Department { get; set; }
    }
}
