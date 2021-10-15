using AutoMapper;
using BitirmeProjesi.Common.DTOs.BillingAddress;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Model.Entities;

namespace BitirmeProjesi.API.Infrastructor.Mapper
{
    public class AssetMapperProfile : Profile
    {
        public AssetMapperProfile()
        {
            CreateMap<BillingAddress, BillingAddressRequest>()
                 .ReverseMap()
                 .IgnoreAllNonExisting()
                 .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<BillingAddress, BillingAddressResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
