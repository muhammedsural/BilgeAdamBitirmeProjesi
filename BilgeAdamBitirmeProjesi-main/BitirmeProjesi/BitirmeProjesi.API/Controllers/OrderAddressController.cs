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
using BitirmeProjesi.Service.Repository.OrderAddress;
using BitirmeProjesi.Common.DTOs.OrderAddress;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("orderaddress")]
    public class OrderAddressController : BaseApiController<OrderAddressController>
    {
        private readonly IOrderAddressRepository _cr;
        private readonly IMapper _mapper;

        public OrderAddressController(
            IOrderAddressRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderAddressResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<OrderAddressResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<OrderAddressResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<OrderAddressResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderAddressResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<OrderAddressResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<OrderAddressResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<OrderAddressResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderAddressResponse>>> PostCategory(OrderAddressRequest request)
        {
            OrderAddress entity = _mapper.Map<OrderAddress>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                OrderAddressResponse rm = _mapper.Map<OrderAddressResponse>(insertResult);
                return new WebApiResponse<OrderAddressResponse>(true, "Success", rm);
            }

            return new WebApiResponse<OrderAddressResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderAddressResponse>>> PutCategory(int id, OrderAddressRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                OrderAddress entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    OrderAddressResponse rm = _mapper.Map<OrderAddressResponse>(updateResult);
                    return new WebApiResponse<OrderAddressResponse>(true, "Success", rm);
                }

                return new WebApiResponse<OrderAddressResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}