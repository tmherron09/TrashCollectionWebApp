using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrashCollection.Models
{
    
    public class LocationResponse
    {
        public results[] results { get; set; }
    }

    public class results
    {
        public geometry Geometry { get; set; }
    }

    public class geometry
    {
        public location Location { get; set; }
    }

    public class location
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

}
