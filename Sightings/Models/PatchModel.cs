using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sightings.Models
{
    public class PatchModel
    {
        public String Op { get; set; }
        public String Path { get; set; }
        public String Value { get; set; }
    }
}