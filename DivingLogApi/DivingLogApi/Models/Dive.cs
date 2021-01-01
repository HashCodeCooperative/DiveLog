using DivingLogApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DivingLogApi.Models
{
    public class Dive
    { 
        public int DiveId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DiveType DiveType { get; set; }
        public Water Water { get; set; }
        public WaterStream WaterStream { get; set; }
        public Weather Weather { get; set; }
        public int AirTemp { get; set; }
        public int WaterTemp { get; set; }
        public int Visibility { get; set; }
        public string Description { get; set; }
        public DiveSite DiveSite { get; set; }
        public List<UserDive> Divers { get; set; }

    }
}
