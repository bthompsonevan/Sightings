using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sightings.Models
{
    public class Repository : Irepository
    {
        private Dictionary<int, Sighting> sightingItems;

        public Repository()
        {
            sightingItems = new Dictionary<int, Sighting>();
            new List<Sighting>
            {
                new Sighting {SightingLocation = "Springfield", SightingDate = DateTime.Parse("02/22/2020")},
                new Sighting {SightingLocation = "Springfield", SightingDate = DateTime.Parse("02/22/2020")},
                new Sighting {SightingLocation = "Springfield", SightingDate = DateTime.Parse("02/22/2020")},
                new Sighting {SightingLocation = "Springfield", SightingDate = DateTime.Parse("02/22/2020")},
                new Sighting {SightingLocation = "Springfield", SightingDate = DateTime.Parse("02/22/2020")},
                new Sighting {SightingLocation = "Springfield", SightingDate = DateTime.Parse("02/22/2020")}

            }
        }


    }
}
