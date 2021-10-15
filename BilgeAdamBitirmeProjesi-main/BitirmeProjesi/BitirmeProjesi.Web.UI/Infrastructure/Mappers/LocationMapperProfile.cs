using AutoMapper;
using BitirmeProjesi.Common.DTOs.Country;
using BitirmeProjesi.Common.DTOs.Location;
using BitirmeProjesi.Common.DTOs.Login;
using BitirmeProjesi.Common.DTOs.Member;
using BitirmeProjesi.Common.DTOs.Town;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.UserViewModels;
using BitirmeProjesi.Web.UI.Models.Home;
using static AutoMapper.Internal.ExpressionFactory;

namespace BitirmeProjesi.Web.UI.Infrastructure.Mappers
{
    public class LocationMapperProfile : Profile
    {
        public LocationMapperProfile()
        {
            CreateMap<CityViewModel, LocationResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CityViewModel, LocationRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));


        }
    }
}