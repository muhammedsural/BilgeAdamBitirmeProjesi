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
using BitirmeProjesi.Service.Repository.PaymentGateway;
using BitirmeProjesi.Common.DTOs.PaymentGateway;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("paymentgateway")]
    public class PaymentGatewayController : BaseApiController<PaymentGatewayController>
    {
        private readonly IPaymentGatewayRepository _cr;
        private readonly IMapper _mapper;

        public PaymentGatewayController(
            IPaymentGatewayRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PaymentGatewayResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<PaymentGatewayResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<PaymentGatewayResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<PaymentGatewayResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<PaymentGatewayResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<PaymentGatewayResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<PaymentGatewayResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<PaymentGatewayResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<PaymentGatewayResponse>>> PostCategory(PaymentGatewayRequest request)
        {
            PaymentGateway entity = _mapper.Map<PaymentGateway>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                PaymentGatewayResponse rm = _mapper.Map<PaymentGatewayResponse>(insertResult);
                return new WebApiResponse<PaymentGatewayResponse>(true, "Success", rm);
            }

            return new WebApiResponse<PaymentGatewayResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<PaymentGatewayResponse>>> PutCategory(int id, PaymentGatewayRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                PaymentGateway entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    PaymentGatewayResponse rm = _mapper.Map<PaymentGatewayResponse>(updateResult);
                    return new WebApiResponse<PaymentGatewayResponse>(true, "Success", rm);
                }

                return new WebApiResponse<PaymentGatewayResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}