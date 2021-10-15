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
using BitirmeProjesi.Service.Repository.ShippingCompany;
using BitirmeProjesi.Common.DTOs.ShippingCompany;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("shippingcompany")]
    public class ShippingCompanyController : BaseApiController<ShippingCompanyController>
    {
        private readonly IShippingCompanyRepository _cr;
        private readonly IMapper _mapper;

        public ShippingCompanyController(
            IShippingCompanyRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ShippingCompanyResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<ShippingCompanyResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<ShippingCompanyResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<ShippingCompanyResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<ShippingCompanyResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<ShippingCompanyResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<ShippingCompanyResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<ShippingCompanyResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ShippingCompanyResponse>>> PostCategory(ShippingCompanyRequest request)
        {
            ShippingCompany entity = _mapper.Map<ShippingCompany>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                ShippingCompanyResponse rm = _mapper.Map<ShippingCompanyResponse>(insertResult);
                return new WebApiResponse<ShippingCompanyResponse>(true, "Success", rm);
            }

            return new WebApiResponse<ShippingCompanyResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ShippingCompanyResponse>>> PutCategory(int id, ShippingCompanyRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                ShippingCompany entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    ShippingCompanyResponse rm = _mapper.Map<ShippingCompanyResponse>(updateResult);
                    return new WebApiResponse<ShippingCompanyResponse>(true, "Success", rm);
                }

                return new WebApiResponse<ShippingCompanyResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}