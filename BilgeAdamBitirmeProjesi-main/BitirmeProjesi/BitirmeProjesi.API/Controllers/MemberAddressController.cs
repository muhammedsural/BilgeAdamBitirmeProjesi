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
using BitirmeProjesi.Service.Repository.MemberAddress;
using BitirmeProjesi.Common.DTOs.MemberAddress;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("memberaddress")]
    public class MemberAddressController : BaseApiController<MemberAddressController>
    {
        private readonly IMemberAddressRepository _cr;
        private readonly IMapper _mapper;

        public MemberAddressController(
            IMemberAddressRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<MemberAddressResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<MemberAddressResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<MemberAddressResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<MemberAddressResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<MemberAddressResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<MemberAddressResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<MemberAddressResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<MemberAddressResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<MemberAddressResponse>>> PostCategory(MemberAddressRequest request)
        {
            MemberAddress entity = _mapper.Map<MemberAddress>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                MemberAddressResponse rm = _mapper.Map<MemberAddressResponse>(insertResult);
                return new WebApiResponse<MemberAddressResponse>(true, "Success", rm);
            }

            return new WebApiResponse<MemberAddressResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<MemberAddressResponse>>> PutCategory(int id, MemberAddressRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                MemberAddress entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    MemberAddressResponse rm = _mapper.Map<MemberAddressResponse>(updateResult);
                    return new WebApiResponse<MemberAddressResponse>(true, "Success", rm);
                }

                return new WebApiResponse<MemberAddressResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}