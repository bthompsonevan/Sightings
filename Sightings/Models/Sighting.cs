using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sightings.Models
{
    public class Sighting
    {
        public int SightingID { get; set; }

        public string SightingLocation { get; set; }

        public DateTime SightingDate { get; set; }
    }
}
