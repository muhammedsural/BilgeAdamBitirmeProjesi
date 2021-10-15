using AutoMapper;
using BitirmeProjesi.Common.DTOs.Member;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.MemberViewModels;

namespace BitirmeProjesi.Web.UI.Infrastructure.Mappers
{
    public class MemberMapperProfile : Profile
    {
        public MemberMapperProfile()
        {
            CreateMap<MemberViewModel, MemberRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<MemberViewModel, MemberResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UpdateCustomerViewModel, MemberRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UpdateCustomerViewModel, MemberResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}