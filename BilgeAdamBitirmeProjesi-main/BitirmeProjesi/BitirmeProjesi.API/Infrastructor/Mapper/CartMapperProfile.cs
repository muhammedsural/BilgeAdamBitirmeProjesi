using AutoMapper;
using BitirmeProjesi.Common.DTOs.Cart;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Infrastructor.Mapper
{
    public class CartMapperProfile : Profile
    {
        public CartMapperProfile()
        {
            CreateMap<Cart, CartRequest>()
                 .ReverseMap()
                 .IgnoreAllNonExisting()
                 .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Cart, CartResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}