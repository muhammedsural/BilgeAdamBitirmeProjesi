using AutoMapper;
using BitirmeProjesi.Common.DTOs.CartItem;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Infrastructor.Mapper
{
    public class CartItemMapperProfile : Profile
    {
        public CartItemMapperProfile()
        {
            CreateMap<CartItem, CartItemRequest>()
                 .ReverseMap()
                 .IgnoreAllNonExisting()
                 .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CartItem, CartItemResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}
