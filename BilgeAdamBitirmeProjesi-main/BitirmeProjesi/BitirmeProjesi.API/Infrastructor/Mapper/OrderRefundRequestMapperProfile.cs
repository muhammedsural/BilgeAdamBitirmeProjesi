using AutoMapper;
using BitirmeProjesi.Common.DTOs.OrderRefundRequest;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Model.Entities;


namespace BitirmeProjesi.API.Infrastructor.Mapper
{
    public class OrderRefundRequestMapperProfile : Profile
    {
        public OrderRefundRequestMapperProfile()
        {
            CreateMap<OrderRefundRequest, OrderRefundRequestResponseDTO>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<OrderRefundRequest, OrderRefundRequestResponseDTO>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}