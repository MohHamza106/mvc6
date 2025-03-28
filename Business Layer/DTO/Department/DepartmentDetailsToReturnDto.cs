using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.DTO.Department
{
    public class DepartmentDetailsToReturnDto
    {
        public int Id { get; set; }
        public int createdbt { get; set; }
        public DateTime createdon { get; set; }
        public int LastModifiedby { get; set; }
        public DateTime LastModifiedat { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Code { get; set; } = null!;

        [Display(Name="creation date ")]
        public DateTime? CreationDate { get; set; }
    }
}
