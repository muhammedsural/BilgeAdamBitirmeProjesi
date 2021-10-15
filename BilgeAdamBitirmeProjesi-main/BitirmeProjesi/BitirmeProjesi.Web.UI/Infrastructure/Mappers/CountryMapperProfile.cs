using AutoMapper;
using BitirmeProjesi.Common.DTOs.Country;
using BitirmeProjesi.Common.DTOs.Login;
using BitirmeProjesi.Common.DTOs.Member;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.UserViewModels;
using BitirmeProjesi.Web.UI.Models.Home;
using static AutoMapper.Internal.ExpressionFactory;

namespace BitirmeProjesi.Web.UI.Infrastructure.Mappers
{
    public class CountryMapperProfile : Profile
    {
        public CountryMapperProfile()
        {
            CreateMap<CountyViewModel, CountryRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CountyViewModel, CountryResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));


        }
    }
}