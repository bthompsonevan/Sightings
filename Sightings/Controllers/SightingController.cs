using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Sightings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sightings.Controllers
{
    //API Controller
    [Route("api/[controller]")]
    public class SightingController : Controller
    {
        private Irepository repository;

        public SightingController(Irepository repo) => repository = repo;

        [HttpGet]
        public IEnumerable<Sighting> Get() => repository.Sightings;

        [HttpGet("{id}")]
        public Sighting Get(int id) => repository[id];

        [HttpPost] 
        public Sighting Post([FromBody] Sighting sig) => 
            repository.AddSighting(new Sighting 
                { SightingLocation = sig.SightingLocation, SightingDate = sig.SightingDate });

        [HttpPut]
        public Sighting Put([FromBody] Sighting sig) =>
            repository.UpdateSighting(sig);

        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id,
            [FromBody]JsonPatchDocument<Sighting> patch)
        {
            Sighting sig = Get(id);
            if (sig != null)
            {
                patch.ApplyTo(sig);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteSighting(id);


    }
}
