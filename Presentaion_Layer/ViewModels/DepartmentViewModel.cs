using System.ComponentModel.DataAnnotations;

namespace Presentaion_Layer.ViewModels
{
    public class DepartmentViewModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Code { get; set; } = null!;
        public DateTime? CreationDate { get; set; }
    }
}
