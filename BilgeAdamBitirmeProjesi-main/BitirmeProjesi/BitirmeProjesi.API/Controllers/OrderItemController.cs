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
using BitirmeProjesi.Service.Repository.OrderItem;
using BitirmeProjesi.Common.DTOs.OrderItem;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("orderitem")]
    public class OrderItemController : BaseApiController<OrderItemController>
    {
        private readonly IOrderItemRepository _cr;
        private readonly IMapper _mapper;

        public OrderItemController(
            IOrderItemRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderItemResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<OrderItemResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<OrderItemResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<OrderItemResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderItemResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<OrderItemResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<OrderItemResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<OrderItemResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderItemResponse>>> PostCategory(OrderItemRequest request)
        {
            OrderItem entity = _mapper.Map<OrderItem>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                OrderItemResponse rm = _mapper.Map<OrderItemResponse>(insertResult);
                return new WebApiResponse<OrderItemResponse>(true, "Success", rm);
            }

            return new WebApiResponse<OrderItemResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderItemResponse>>> PutCategory(int id, OrderItemRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                OrderItem entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    OrderItemResponse rm = _mapper.Map<OrderItemResponse>(updateResult);
                    return new WebApiResponse<OrderItemResponse>(true, "Success", rm);
                }

                return new WebApiResponse<OrderItemResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}