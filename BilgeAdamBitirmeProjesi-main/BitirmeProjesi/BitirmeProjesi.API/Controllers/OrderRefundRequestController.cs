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
using BitirmeProjesi.Service.Repository.OrderRefundRequest;
using BitirmeProjesi.Common.DTOs.OrderRefundRequest;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("orderrefundrequest")]
    public class OrderRefundRequestController : BaseApiController<OrderRefundRequestController>
    {
        private readonly IOrderRefundRequestRepository _cr;
        private readonly IMapper _mapper;

        public OrderRefundRequestController(
            IOrderRefundRequestRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderRefundRequestResponseDTO>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult =
                _mapper.Map<List<OrderRefundRequestResponseDTO>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<OrderRefundRequestResponseDTO>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<OrderRefundRequestResponseDTO>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderRefundRequestResponseDTO>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<OrderRefundRequestResponseDTO>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<OrderRefundRequestResponseDTO>(true, "Success", categoryResult);
            }

            return new WebApiResponse<OrderRefundRequestResponseDTO>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderRefundRequestResponseDTO>>> PostCategory(
            OrderRefundRequestDTO request)
        {
            OrderRefundRequest entity = _mapper.Map<OrderRefundRequest>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                OrderRefundRequestResponseDTO rm = _mapper.Map<OrderRefundRequestResponseDTO>(insertResult);
                return new WebApiResponse<OrderRefundRequestResponseDTO>(true, "Success", rm);
            }

            return new WebApiResponse<OrderRefundRequestResponseDTO>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderRefundRequestResponseDTO>>> PutCategory(int id,
            OrderRefundRequestDTO request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                OrderRefundRequest entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    OrderRefundRequestResponseDTO rm = _mapper.Map<OrderRefundRequestResponseDTO>(updateResult);
                    return new WebApiResponse<OrderRefundRequestResponseDTO>(true, "Success", rm);
                }

                return new WebApiResponse<OrderRefundRequestResponseDTO>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}