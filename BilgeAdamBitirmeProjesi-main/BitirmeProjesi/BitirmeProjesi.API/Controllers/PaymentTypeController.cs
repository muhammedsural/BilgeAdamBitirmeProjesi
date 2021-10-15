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
using BitirmeProjesi.Service.Repository.PaymentType;
using BitirmeProjesi.Common.DTOs.PaymentType;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("paymenttype")]
    public class PaymentTypeController : BaseApiController<PaymentTypeController>
    {
        private readonly IPaymentTypeRepository _cr;
        private readonly IMapper _mapper;

        public PaymentTypeController(
            IPaymentTypeRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PaymentTypeResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<PaymentTypeResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<PaymentTypeResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<PaymentTypeResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<PaymentTypeResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<PaymentTypeResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<PaymentTypeResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<PaymentTypeResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<PaymentTypeResponse>>> PostCategory(PaymentTypeRequest request)
        {
            PaymentType entity = _mapper.Map<PaymentType>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                PaymentTypeResponse rm = _mapper.Map<PaymentTypeResponse>(insertResult);
                return new WebApiResponse<PaymentTypeResponse>(true, "Success", rm);
            }

            return new WebApiResponse<PaymentTypeResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<PaymentTypeResponse>>> PutCategory(int id, PaymentTypeRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                PaymentType entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    PaymentTypeResponse rm = _mapper.Map<PaymentTypeResponse>(updateResult);
                    return new WebApiResponse<PaymentTypeResponse>(true, "Success", rm);
                }

                return new WebApiResponse<PaymentTypeResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}