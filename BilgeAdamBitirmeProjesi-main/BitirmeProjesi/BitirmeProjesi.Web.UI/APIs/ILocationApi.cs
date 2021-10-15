using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BitirmeProjesi.Common.DTOs.Cart;
using BitirmeProjesi.Common.DTOs.CartItem;
using BitirmeProjesi.Common.DTOs.Location;
using BitirmeProjesi.Common.DTOs.Product;
using BitirmeProjesi.Common.DTOs.Town;
using BitirmeProjesi.Common.Models;
using BitirmeProjesi.Web.UI.Areas.Admin.Models.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace BitirmeProjesi.Web.UI.APIs
{
    [Headers("Authorization: Bearer", "Content-Type: application/json")]
    public interface ILocationApi
    {
        [Get("/Location")]
        Task<ApiResponse<WebApiResponse<List<LocationResponse>>>> List();
    }
}