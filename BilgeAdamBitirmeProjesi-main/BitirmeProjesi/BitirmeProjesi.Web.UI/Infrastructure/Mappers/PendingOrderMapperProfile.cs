using AutoMapper;

using BitirmeProjesi.Common.DTOs.Order;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.PendingOrderViewModels;

using static AutoMapper.Internal.ExpressionFactory;

namespace BitirmeProjesi.Web.UI.Infrastructure.Mappers
{
    public class PendingOrderMapperProfile : Profile
    {
        public PendingOrderMapperProfile()
        {
            CreateMap<PendingOrderViewModel, OrderRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<PendingOrderViewModel, OrderResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}