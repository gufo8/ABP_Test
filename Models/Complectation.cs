using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP_Test.Models
{
    public class Complectation
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string FuelInduction { get; set; }
        public string BuildingCondition { get; set; }
        public string Grade { get; set; }
        public string Transmission { get; set; }
        public string GearShiftType { get; set; }
        public string Cab { get; set; }
        public string TransmissionModel { get; set; }
        public string LoadingCapacity { get; set; }
        public string RearTide { get; set; }
        public string Destination { get; set; }

        //FK + nav prop
        public int CarModelID { get; set; }
        public virtual CarModel CarModel { get; set; }
        public virtual ICollection<GroupParts> GroupParts { get; set; }

    }
}
