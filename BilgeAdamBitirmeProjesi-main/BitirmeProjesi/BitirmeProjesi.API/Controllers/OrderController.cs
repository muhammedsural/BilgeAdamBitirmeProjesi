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
using BitirmeProjesi.Service.Repository.Order;
using BitirmeProjesi.Common.DTOs.Order;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("order")]
    public class OrderController : BaseApiController<OrderController>
    {
        private readonly IOrderRepository _cr;
        private readonly IMapper _mapper;

        public OrderController(
            IOrderRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<OrderResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<OrderResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<OrderResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<OrderResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<OrderResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<OrderResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderResponse>>> PostCategory(OrderRequest request)
        {
            Order entity = _mapper.Map<Order>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                OrderResponse rm = _mapper.Map<OrderResponse>(insertResult);
                return new WebApiResponse<OrderResponse>(true, "Success", rm);
            }

            return new WebApiResponse<OrderResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderResponse>>> PutCategory(int id, OrderRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Order entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    OrderResponse rm = _mapper.Map<OrderResponse>(updateResult);
                    return new WebApiResponse<OrderResponse>(true, "Success", rm);
                }

                return new WebApiResponse<OrderResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}