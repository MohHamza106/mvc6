using Data_Aceess_Layer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Aceess_Layer
{
    public class Model_Base
    {
        public int Id { get; set; }
        public int createdbt { get; set; }
        public DateTime createdon { get; set; }
        public int LastModifiedby { get; set; }
        public DateTime LastModifiedat { get; set; }
        public bool IsDeleted { get; set; }
        public Departments ? Departments { get; set; }

    }
}
