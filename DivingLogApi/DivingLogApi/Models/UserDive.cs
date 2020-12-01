using DivingLogApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivingLogApi.Models
{
    public class UserDive
    {
        public int UserDiveId { get; set; }
        public DivingSuit DivingSuit { get; set; }
        public Gas Gas { get; set; }
        public CylinderType CylinderType { get; set; }
        public int DurationInMinutes { get; set; }
        public int CylinderCapacity { get; set; }
        public int CylStartPressure { get; set; }
        public int CylEndPressure { get; set; }
        public float SurfaceAirConsumption { get; set; }
        public float MaxDepth { get; set; }
        public float AvgDepth { get; set; }
        public int Ballast { get; set; }
        public string Notes { get; set; }
        public User User { get; set; }
        public Dive Dive { get; set; }
    }
}
