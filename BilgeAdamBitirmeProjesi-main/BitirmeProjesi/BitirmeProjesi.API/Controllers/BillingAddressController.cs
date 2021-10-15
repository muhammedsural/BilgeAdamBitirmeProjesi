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
using BitirmeProjesi.Service.Repository.BillingAddress;
using BitirmeProjesi.Common.DTOs.BillingAddress;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("billingaddress")]
    public class BillingAddressController : BaseApiController<BillingAddressController>
    {
        private readonly IBillingAddressRepository _cr;
        private readonly IMapper _mapper;

        public BillingAddressController(
            IBillingAddressRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<BillingAddressResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<BillingAddressResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<BillingAddressResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<BillingAddressResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<BillingAddressResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<BillingAddressResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<BillingAddressResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<BillingAddressResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<BillingAddressResponse>>> PostCategory(BillingAddressRequest request)
        {
            BillingAddress entity = _mapper.Map<BillingAddress>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                BillingAddressResponse rm = _mapper.Map<BillingAddressResponse>(insertResult);
                return new WebApiResponse<BillingAddressResponse>(true, "Success", rm);
            }

            return new WebApiResponse<BillingAddressResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<BillingAddressResponse>>> PutCategory(int id, BillingAddressRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                BillingAddress entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    BillingAddressResponse rm = _mapper.Map<BillingAddressResponse>(updateResult);
                    return new WebApiResponse<BillingAddressResponse>(true, "Success", rm);
                }

                return new WebApiResponse<BillingAddressResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}