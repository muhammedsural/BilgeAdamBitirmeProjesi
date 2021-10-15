using AutoMapper;
using BitirmeProjesi.Common.DTOs.Login;
using BitirmeProjesi.Common.DTOs.Member;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Web.UI.Models.AccountViewModels;

namespace BitirmeProjesi.Web.UI.Infrastructure.Mappers
{
    public class AccountMapperProfile : Profile
    {
        public AccountMapperProfile()
        {
            CreateMap<LoginViewModel, LoginRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<LoginViewModel, MemberResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
