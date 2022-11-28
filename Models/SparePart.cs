using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP_Test.Models
{
    public class SparePart
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        //FK + nav prop
        public int SubGroupID { get; set; }
        public virtual SubGroup SubGroups { get; set; }


    }
}
