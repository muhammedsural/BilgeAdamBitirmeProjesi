using AutoMapper;
using BitirmeProjesi.Common.DTOs.Product;
using BitirmeProjesi.Common.Extensions;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.ProductViewModels;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.UpdateProductViewModels;
using BitirmeProjesi.Web.UI.Models.Home;

namespace BitirmeProjesi.Web.UI.Infrastructure.Mappers
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<ProductViewModel, ProductRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ProductViewModel, ProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CreateProductViewModel, ProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CreateProductViewModel, ProductRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UpdateProductViewModel, ProductRequest>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UpdateProductViewModel, ProductResponse>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<ShopGridRequestModel, ShopGridRequestModelDTO>()
                .ReverseMap()
                .IgnoreAllNonExisting()
                .ForAllMembers(option => option.Condition((src, dest, srcMember) => srcMember != null));
            
        }
    }
}