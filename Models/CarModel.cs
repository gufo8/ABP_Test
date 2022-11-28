using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP_Test.Models
{    
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ManufactureDate { get; set; }
        public string Series { get; set; }

        //nav prop
        public virtual ICollection<Complectation> Complectations { get; set; }        
    }
}
