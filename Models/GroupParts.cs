using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP_Test.Models
{
    public class GroupParts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //FK + nav prop
        public int ComplectationID { get; set; }
        public virtual Complectation Complectation { get; set; }
        public virtual ICollection<SubGroup> SubGroups { get; set; }
    }
}
