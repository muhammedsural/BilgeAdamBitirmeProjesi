using AutoMapper;
using BitirmeProjesi.API.Controllers.Base;
using BitirmeProjesi.Common.DTOs.Member;
using BitirmeProjesi.Common.Models;
using BitirmeProjesi.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using BitirmeProjesi.Service.Repository.FavouritedProduct;
using BitirmeProjesi.Common.DTOs.FavouritedProduct;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("favouritedproduct")]
    public class FavouritedProductController : BaseApiController<FavouritedProductController>
    {
        private readonly IFavouritedProductRepository _cr;
        private readonly IMapper _mapper;

        public FavouritedProductController(
            IFavouritedProductRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<FavouritedProductResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<FavouritedProductResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<FavouritedProductResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<FavouritedProductResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<FavouritedProductResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<FavouritedProductResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<FavouritedProductResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<FavouritedProductResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<FavouritedProductResponse>>> PostCategory(FavouritedProductRequest request)
        {
            FavouritedProduct entity = _mapper.Map<FavouritedProduct>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                FavouritedProductResponse rm = _mapper.Map<FavouritedProductResponse>(insertResult);
                return new WebApiResponse<FavouritedProductResponse>(true, "Success", rm);
            }

            return new WebApiResponse<FavouritedProductResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<FavouritedProductResponse>>> PutCategory(int id, FavouritedProductRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                FavouritedProduct entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    FavouritedProductResponse rm = _mapper.Map<FavouritedProductResponse>(updateResult);
                    return new WebApiResponse<FavouritedProductResponse>(true, "Success", rm);
                }

                return new WebApiResponse<FavouritedProductResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}