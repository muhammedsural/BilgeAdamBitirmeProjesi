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
using BitirmeProjesi.Service.Repository.Payment;
using BitirmeProjesi.Common.DTOs.Payment;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("payment")]
    public class PaymentController : BaseApiController<PaymentController>
    {
        private readonly IPaymentRepository _cr;
        private readonly IMapper _mapper;

        public PaymentController(
            IPaymentRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PaymentResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<PaymentResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<PaymentResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<PaymentResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<PaymentResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<PaymentResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<PaymentResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<PaymentResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<PaymentResponse>>> PostCategory(PaymentRequest request)
        {
            Payment entity = _mapper.Map<Payment>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                PaymentResponse rm = _mapper.Map<PaymentResponse>(insertResult);
                return new WebApiResponse<PaymentResponse>(true, "Success", rm);
            }

            return new WebApiResponse<PaymentResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<PaymentResponse>>> PutCategory(int id, PaymentRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Payment entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    PaymentResponse rm = _mapper.Map<PaymentResponse>(updateResult);
                    return new WebApiResponse<PaymentResponse>(true, "Success", rm);
                }

                return new WebApiResponse<PaymentResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}