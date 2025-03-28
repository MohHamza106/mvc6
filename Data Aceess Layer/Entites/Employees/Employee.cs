using Data_Aceess_Layer.Entites.common.Enums;
using Data_Aceess_Layer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Aceess_Layer
{
    public class Employee : Model_Base
    {
        public string Name { get; set; } = null!;
        public int ? Age { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly HiringDate { get; set; }
        public Gender gender { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public Departments ? departments { get; set; }
        public int ? departmentsID { get; set; }
    }
}
