using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivingLogApi.Models
{
    public class DiveSite
    {
        public int DiveSiteId { get; set; }
        public string Name { get; set; }
        public string GPSPosition { get; set; }
        public string Description { get; set; }
        //public List<Dive> Dives { get; set; }

    }
}
