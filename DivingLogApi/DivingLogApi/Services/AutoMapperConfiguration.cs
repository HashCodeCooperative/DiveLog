using AutoMapper;
using DivingLogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivingLogApi.Services
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration( ) : base()
        {
            CreateMap<Dive, Dive>().ForMember(n=>n.DiveId, conf => conf.UseDestinationValue());
        }
    }
}
