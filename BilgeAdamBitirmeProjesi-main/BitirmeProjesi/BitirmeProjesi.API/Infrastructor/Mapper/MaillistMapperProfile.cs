using AutoMapper;
using BitirmeProjesi.Common.DTOs.Maillist;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Infrastructor.Mapper
{
    public class MaillistMapperProfile : Profile
    {
        public MaillistMapperProfile()
        {
            CreateMap<Maillist, MaillistRequest>()
                 .ReverseMap()
                 .IgnoreAllNonExisting()
                 .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Maillist, MaillistResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}