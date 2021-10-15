using AutoMapper;
using BitirmeProjesi.Common.DTOs.Brand;
using BitirmeProjesi.Common.DTOs.Cart;
using BitirmeProjesi.Common.DTOs.CartItem;
using BitirmeProjesi.Common.DTOs.Category;
using BitirmeProjesi.Common.DTOs.Login;
using BitirmeProjesi.Common.DTOs.Member;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.BrandViewModels;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.CartViewModels;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.UserViewModels;
using static AutoMapper.Internal.ExpressionFactory;

namespace BitirmeProjesi.Web.UI.Infrastructure.Mappers
{
    public class CartMapperProfile : Profile
    {
        public CartMapperProfile()
        {
            CreateMap<CartViewModel, CartItemRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<CartViewModel, CartItemResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}