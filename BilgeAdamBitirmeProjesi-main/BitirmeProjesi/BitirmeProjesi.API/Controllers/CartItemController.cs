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
using BitirmeProjesi.Service.Repository.CartItem;
using BitirmeProjesi.Common.DTOs.CartItem;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("cartitem")]
    public class CartItemController : BaseApiController<CartItemController>
    {
        private readonly ICartItemRepository _cr;
        private readonly IMapper _mapper;

        public CartItemController(
            ICartItemRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<CartItemResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<CartItemResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<CartItemResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<CartItemResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<CartItemResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<CartItemResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<CartItemResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<CartItemResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CartItemResponse>>> PostCategory(CartItemRequest request)
        {
            CartItem entity = _mapper.Map<CartItem>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                CartItemResponse rm = _mapper.Map<CartItemResponse>(insertResult);
                return new WebApiResponse<CartItemResponse>(true, "Success", rm);
            }

            return new WebApiResponse<CartItemResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CartItemResponse>>> PutCategory(int id, CartItemRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                CartItem entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    CartItemResponse rm = _mapper.Map<CartItemResponse>(updateResult);
                    return new WebApiResponse<CartItemResponse>(true, "Success", rm);
                }

                return new WebApiResponse<CartItemResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}