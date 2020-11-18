﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivingLogApi.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WaterStream
    {
        Brak,
        Lekki,
        Silny
    }
}
