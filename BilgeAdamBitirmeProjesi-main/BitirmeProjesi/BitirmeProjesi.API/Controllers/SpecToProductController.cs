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
using BitirmeProjesi.Service.Repository.SpecToProduct;
using BitirmeProjesi.Common.DTOs.SpecToProduct;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("spectoproduct")]
    public class SpecToProductController : BaseApiController<SpecToProductController>
    {
        private readonly ISpecToProductRepository _cr;
        private readonly IMapper _mapper;

        public SpecToProductController(
            ISpecToProductRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<SpecToProductResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<SpecToProductResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<SpecToProductResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<SpecToProductResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecToProductResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<SpecToProductResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<SpecToProductResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<SpecToProductResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<SpecToProductResponse>>> PostCategory(SpecToProductRequest request)
        {
            SpecToProduct entity = _mapper.Map<SpecToProduct>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                SpecToProductResponse rm = _mapper.Map<SpecToProductResponse>(insertResult);
                return new WebApiResponse<SpecToProductResponse>(true, "Success", rm);
            }

            return new WebApiResponse<SpecToProductResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecToProductResponse>>> PutCategory(int id, SpecToProductRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                SpecToProduct entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    SpecToProductResponse rm = _mapper.Map<SpecToProductResponse>(updateResult);
                    return new WebApiResponse<SpecToProductResponse>(true, "Success", rm);
                }

                return new WebApiResponse<SpecToProductResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}