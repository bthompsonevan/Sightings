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
        public Sighting Post(Sighting sig) => 
            repository.AddSighting(new Sighting 
                { SightingID = sig.SightingID, SightingLocation = sig.SightingLocation, SightingDate = sig.SightingDate });

        [HttpPut]
        public Sighting Put([FromBody] Sighting sig) =>
            repository.UpdateSighting(sig);

        //[HttpPatch("{id}")]
        //public StatusCodeResult Patch(int id,
        //    [FromBody]JsonPatchDocument<Sighting> patch)
        //{
        //    Sighting sig = Get(id);
        //    if (sig != null)
        //    {
        //        patch.ApplyTo(sig);
        //        return Ok();
        //    }
        //    return NotFound();
        //}

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]PatchModel patchVm)
        {
            // TODO: Add support for more ops: remove, copy, move, test

            Sighting sig = Get(id);
            switch (patchVm.Path)
            {
                case "sightingLocation":
                    sig.SightingLocation = patchVm.Value;
                    break;
                case "sightingDate":
                    sig.SightingDate = Convert.ToDateTime(patchVm.Value);
                    break;
                default:
                    return BadRequest();
            }
            //repository.Edit(sig);
            return Ok(sig);
        }

        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteSighting(id);


    }
}
