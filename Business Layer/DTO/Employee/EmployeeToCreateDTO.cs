using Data_Aceess_Layer.Entites.common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.DTO.Employee
{
    public class EmployeeToCreateDTO
    {
        [Required]
        [MaxLength (50 , ErrorMessage ="max length should be 50 character")]
        [MinLength (5 , ErrorMessage ="min length should be 5 character")]
        public string Name { get; set; } = null!;
        
        [Range(22,30)]
        public int Age { get; set; }
        
        [RegularExpression(@"[6,9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5-10}$",
            ErrorMessage = "Address must be like 123-street-city-country")]
        public string Address { get; set; } = null!;
        
        [DataType(DataType.Currency)]
        public decimal salary { get; set; }
        
        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }

        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        public string ? phoneNumber { get; set; }
         
        public DateOnly HiringDate { get; set; }
        public Gender gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        [Display(Name="Department")]
        public int? Depaertmentid { get; set; }
    
    }
}
