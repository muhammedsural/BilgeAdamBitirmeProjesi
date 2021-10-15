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
using BitirmeProjesi.Service.Repository.ShippingProvider;
using BitirmeProjesi.Common.DTOs.ShippingProvider;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("shippingprovider")]
    public class ShippingProviderController : BaseApiController<ShippingProviderController>
    {
        private readonly IShippingProviderRepository _cr;
        private readonly IMapper _mapper;

        public ShippingProviderController(
            IShippingProviderRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ShippingProviderResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<ShippingProviderResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<ShippingProviderResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<ShippingProviderResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<ShippingProviderResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<ShippingProviderResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<ShippingProviderResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<ShippingProviderResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ShippingProviderResponse>>> PostCategory(ShippingProviderRequest request)
        {
            ShippingProvider entity = _mapper.Map<ShippingProvider>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                ShippingProviderResponse rm = _mapper.Map<ShippingProviderResponse>(insertResult);
                return new WebApiResponse<ShippingProviderResponse>(true, "Success", rm);
            }

            return new WebApiResponse<ShippingProviderResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ShippingProviderResponse>>> PutCategory(int id, ShippingProviderRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                ShippingProvider entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    ShippingProviderResponse rm = _mapper.Map<ShippingProviderResponse>(updateResult);
                    return new WebApiResponse<ShippingProviderResponse>(true, "Success", rm);
                }

                return new WebApiResponse<ShippingProviderResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}