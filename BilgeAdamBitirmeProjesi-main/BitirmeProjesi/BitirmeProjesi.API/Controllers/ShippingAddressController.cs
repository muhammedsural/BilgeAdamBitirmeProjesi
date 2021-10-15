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
using BitirmeProjesi.Service.Repository.ShippingAddress;
using BitirmeProjesi.Common.DTOs.ShippingAddress;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("shippingaddress")]
    public class ShippingAddressController : BaseApiController<ShippingAddressController>
    {
        private readonly IShippingAddressRepository _cr;
        private readonly IMapper _mapper;

        public ShippingAddressController(
            IShippingAddressRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ShippingAddressResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<ShippingAddressResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<ShippingAddressResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<ShippingAddressResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<ShippingAddressResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<ShippingAddressResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<ShippingAddressResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<ShippingAddressResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ShippingAddressResponse>>> PostCategory(ShippingAddressRequest request)
        {
            ShippingAddress entity = _mapper.Map<ShippingAddress>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                ShippingAddressResponse rm = _mapper.Map<ShippingAddressResponse>(insertResult);
                return new WebApiResponse<ShippingAddressResponse>(true, "Success", rm);
            }

            return new WebApiResponse<ShippingAddressResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ShippingAddressResponse>>> PutCategory(int id, ShippingAddressRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                ShippingAddress entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    ShippingAddressResponse rm = _mapper.Map<ShippingAddressResponse>(updateResult);
                    return new WebApiResponse<ShippingAddressResponse>(true, "Success", rm);
                }

                return new WebApiResponse<ShippingAddressResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}