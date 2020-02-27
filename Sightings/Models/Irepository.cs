using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sightings.Models
{
    public interface Irepository
    {
        IEnumerable<Sighting> Sightings { get; }
        Sighting this[int id] { get; }

        Sighting AddSighting(Sighting sighting);
        Sighting UpdateSighting(Sighting sighting);
        void DeleteSighting(int id);


    }
}
