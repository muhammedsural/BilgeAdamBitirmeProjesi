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
using BitirmeProjesi.Service.Repository.OrderRefundRequestItem;
using BitirmeProjesi.Common.DTOs.OrderRefundRequestItem;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("orderrefundrequestitem")]
    public class OrderRefundRequestItemController : BaseApiController<OrderRefundRequestItemController>
    {
        private readonly IOrderRefundRequestItemRepository _cr;
        private readonly IMapper _mapper;

        public OrderRefundRequestItemController(
            IOrderRefundRequestItemRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderRefundRequestItemResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<OrderRefundRequestItemResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<OrderRefundRequestItemResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<OrderRefundRequestItemResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderRefundRequestItemResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<OrderRefundRequestItemResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<OrderRefundRequestItemResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<OrderRefundRequestItemResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderRefundRequestItemResponse>>> PostCategory(OrderRefundRequestItemRequest request)
        {
            OrderRefundRequestItem entity = _mapper.Map<OrderRefundRequestItem>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                OrderRefundRequestItemResponse rm = _mapper.Map<OrderRefundRequestItemResponse>(insertResult);
                return new WebApiResponse<OrderRefundRequestItemResponse>(true, "Success", rm);
            }

            return new WebApiResponse<OrderRefundRequestItemResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderRefundRequestItemResponse>>> PutCategory(int id, OrderRefundRequestItemRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                OrderRefundRequestItem entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    OrderRefundRequestItemResponse rm = _mapper.Map<OrderRefundRequestItemResponse>(updateResult);
                    return new WebApiResponse<OrderRefundRequestItemResponse>(true, "Success", rm);
                }

                return new WebApiResponse<OrderRefundRequestItemResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}