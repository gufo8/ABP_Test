using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP_Test.Models
{
    public class SubGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //FK + nav prop
        public int GroupPartsID { get; set; }
        public virtual GroupParts GroupParts { get; set; }
        public virtual ICollection<SparePart> SpareParts { get; set; }
    }
}
