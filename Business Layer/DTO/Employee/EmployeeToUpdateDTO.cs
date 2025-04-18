﻿using Data_Aceess_Layer.Entites.common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.DTO.Employee
{
    public class EmployeeToUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly HiringDate { get; set; }
        public Gender gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        
        [Display(Name = "Department")]
        public int? Depaertmentid { get; set; }
    }
}
