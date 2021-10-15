using AutoMapper;
using BitirmeProjesi.Common.DTOs.FavouritedProduct;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Infrastructor.Mapper
{
    public class FavouritedProductMapperProfile : Profile
    {
        public FavouritedProductMapperProfile()
        {
            CreateMap<FavouritedProduct, FavouritedProductRequest>()
                 .ReverseMap()
                 .IgnoreAllNonExisting()
                 .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<FavouritedProduct, FavouritedProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

        }
    }
}