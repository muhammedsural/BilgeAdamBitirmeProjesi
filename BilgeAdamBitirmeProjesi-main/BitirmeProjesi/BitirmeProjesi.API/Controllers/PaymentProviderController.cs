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
using BitirmeProjesi.Service.Repository.PaymentProvider;
using BitirmeProjesi.Common.DTOs.PaymentProvider;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("paymentprovider")]
    public class PaymentProviderController : BaseApiController<PaymentProviderController>
    {
        private readonly IPaymentProviderRepository _cr;
        private readonly IMapper _mapper;

        public PaymentProviderController(
            IPaymentProviderRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<PaymentProviderResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<PaymentProviderResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<PaymentProviderResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<PaymentProviderResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<PaymentProviderResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<PaymentProviderResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<PaymentProviderResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<PaymentProviderResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<PaymentProviderResponse>>> PostCategory(PaymentProviderRequest request)
        {
            PaymentProvider entity = _mapper.Map<PaymentProvider>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                PaymentProviderResponse rm = _mapper.Map<PaymentProviderResponse>(insertResult);
                return new WebApiResponse<PaymentProviderResponse>(true, "Success", rm);
            }

            return new WebApiResponse<PaymentProviderResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<PaymentProviderResponse>>> PutCategory(int id, PaymentProviderRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                PaymentProvider entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    PaymentProviderResponse rm = _mapper.Map<PaymentProviderResponse>(updateResult);
                    return new WebApiResponse<PaymentProviderResponse>(true, "Success", rm);
                }

                return new WebApiResponse<PaymentProviderResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}