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
using System.Linq;
using BitirmeProjesi.Service.Repository.Cart;
using BitirmeProjesi.Common.DTOs.Cart;
using System.Threading.Tasks;
using BitirmeProjesi.Common.DTOs.CartItem;
using BitirmeProjesi.Service.Repository.CartItem;

namespace BitirmeProjesi.API.Controllers
{
    [Route("cart")]
    public class CartController : BaseApiController<CartController>
    {
        private readonly ICartRepository _cr;
        private readonly ICartItemRepository _cir;
        private readonly IMapper _mapper;

        public CartController(
            ICartRepository cr,
            ICartItemRepository cir,
            IMapper mapper
        )
        {
            _cr = cr;
            _cir = cir;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<CartItemResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult =
                _mapper.Map<List<CartItemResponse>>(await _cir.Table.Include(i => i.Cart)
                    .Where(i => i.Cart.MemberId == currentUser.Id).ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<CartItemResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<CartItemResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<CartResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<CartResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<CartResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<CartResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<CartResponse>>> PostCategory(CartItemRequest request)
        {
            Cart insertResult = null;
            MemberResponse currentUser = WorkContext.CurrentUser;

            if (_cr.Table.Any(i => i.MemberId == currentUser.Id))
            {
                var guncelle = _cr.Table.FirstOrDefault(i => i.MemberId == currentUser.Id);
                guncelle.CartItem.Add(_mapper.Map<CartItem>(request));
                insertResult = await _cr.Update(guncelle);
            }
            else
            {
                Cart cart = new Cart();
                cart.createdAt = DateTime.Now;
                cart.MemberId = currentUser.Id;
                cart.updatedAt = DateTime.Now;
                cart.CartItem.Add(_mapper.Map<CartItem>(request));
                insertResult = await _cr.Add(cart);
            }

            if (insertResult != null)
            {
                CartResponse rm = _mapper.Map<CartResponse>(insertResult);
                return new WebApiResponse<CartResponse>(true, "Success", rm);
            }

            return new WebApiResponse<CartResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<CartResponse>>> PutCategory(int id, CartRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Cart entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    CartResponse rm = _mapper.Map<CartResponse>(updateResult);
                    return new WebApiResponse<CartResponse>(true, "Success", rm);
                }

                return new WebApiResponse<CartResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<CartResponse>>> DeleteCategory(int id)
        {
            var categoryResult = await _cir.Remove(id);
            if (categoryResult != false)
            {
                return new WebApiResponse<CartResponse>(true, "Success", null);
            }

            return new WebApiResponse<CartResponse>(false, "Error");
        }
    }
}