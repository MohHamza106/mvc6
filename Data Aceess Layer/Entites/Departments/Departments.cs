using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data_Aceess_Layer
{
    public class Departments : Model_Base
    {
        public string Name { get; set; } = null!;
        public string ? Description { get; set; }
        public string Code { get; set; } = null!;
        public DateTime? CreationDate { get; set; }

        public ICollection<Employee> Employees { get; set; } = null!;
    }
}
