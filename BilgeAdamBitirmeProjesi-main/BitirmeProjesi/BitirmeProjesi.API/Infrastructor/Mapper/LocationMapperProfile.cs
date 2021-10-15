using AutoMapper;
using BitirmeProjesi.Common.DTOs.Location;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Infrastructor.Mapper
{
    public class LocationMapperProfile : Profile
    {
        public LocationMapperProfile()
        {
            CreateMap<Location, LocationRequest>()
                 .ReverseMap()
                 .IgnoreAllNonExisting()
                 .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Location, LocationResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}