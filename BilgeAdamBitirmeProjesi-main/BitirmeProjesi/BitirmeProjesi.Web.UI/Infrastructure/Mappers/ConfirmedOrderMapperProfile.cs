using AutoMapper;

using BitirmeProjesi.Common.DTOs.Order;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.ConfirmedOrderViewModels;

using static AutoMapper.Internal.ExpressionFactory;

namespace BitirmeProjesi.Web.UI.Infrastructure.Mappers
{
    public class ConfirmedOrderMapperProfile : Profile
    {
        public ConfirmedOrderMapperProfile()
        {
            CreateMap<ConfirmedOrderViewModel, OrderRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ConfirmedOrderViewModel, OrderResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}