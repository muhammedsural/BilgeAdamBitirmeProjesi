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
using BitirmeProjesi.Service.Repository.Brand;
using BitirmeProjesi.Common.DTOs.Brand;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("brand")]
    public class BrandController : BaseApiController<BrandController>
    {
        private readonly IBrandRepository _cr;
        private readonly IMapper _mapper;

        public BrandController(
            IBrandRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<BrandResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<BrandResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<BrandResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<BrandResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<BrandResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<BrandResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<BrandResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<BrandResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<BrandResponse>>> PostCategory(BrandRequest request)
        {
            Brand entity = _mapper.Map<Brand>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                BrandResponse rm = _mapper.Map<BrandResponse>(insertResult);
                return new WebApiResponse<BrandResponse>(true, "Success", rm);
            }

            return new WebApiResponse<BrandResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<BrandResponse>>> PutCategory(int id, BrandRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Brand entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    BrandResponse rm = _mapper.Map<BrandResponse>(updateResult);
                    return new WebApiResponse<BrandResponse>(true, "Success", rm);
                }

                return new WebApiResponse<BrandResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<BrandResponse>>> Delete(int id)
        {

            try
            {
                var returnBool = await _cr.Remove(id);
                if (returnBool == true)
                    return new WebApiResponse<BrandResponse>(true, "Success");

                return new WebApiResponse<BrandResponse>(false, "Error");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}