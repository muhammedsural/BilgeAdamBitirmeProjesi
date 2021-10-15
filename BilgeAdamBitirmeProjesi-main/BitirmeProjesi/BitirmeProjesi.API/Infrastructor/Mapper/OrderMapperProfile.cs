using AutoMapper;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Model.Entities;
using BitirmeProjesi.Common.DTOs.Order;

namespace BitirmeProjesi.API.Infrastructor.Mapper
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<Order, OrderRequest>()
                 .ReverseMap()
                 .IgnoreAllNonExisting()
                 .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Order, OrderResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
