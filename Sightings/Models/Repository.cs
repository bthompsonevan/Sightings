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
                new Sighting {SightingLocation = "Lane County", SightingDate = DateTime.Parse("02/22/2020")},
                new Sighting {SightingLocation = "Lane County", SightingDate = DateTime.Parse("07/23/1984")},
                new Sighting {SightingLocation = "Marion County", SightingDate = DateTime.Parse("08/26/1992")},
                new Sighting {SightingLocation = "Columbia County", SightingDate = DateTime.Parse("10/05/1989")},
                new Sighting {SightingLocation = "Mulnoth County", SightingDate = DateTime.Parse("03/15/2001")},
                new Sighting {SightingLocation = "Linn County", SightingDate = DateTime.Parse("05/09/1982")}
                 }.ForEach(r=>AddSighting(r));
            }

            public Sighting this [int id] => sightingItems.ContainsKey(id) ? sightingItems[id] : null;

        public IEnumerable<Sighting> Sightings => sightingItems.Values;

        public Sighting AddSighting(Sighting sighting)
        {
            if (sighting.SightingID == 0)
            {
                int key = sightingItems.Count;
                while (sightingItems.ContainsKey(key)) { key++; };
                sighting.SightingID = key;
            }
            sightingItems[sighting.SightingID] = sighting;
            return sighting;
        }

        public void DeleteSighting(int id) => sightingItems.Remove(id);

        public Sighting UpdateSighting(Sighting sighting)
            => AddSighting(sighting);

    }
}
