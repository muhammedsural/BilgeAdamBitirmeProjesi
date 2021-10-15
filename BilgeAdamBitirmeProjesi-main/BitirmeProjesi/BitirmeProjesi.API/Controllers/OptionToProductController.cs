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
using BitirmeProjesi.Service.Repository.OptionToProduct;
using BitirmeProjesi.Common.DTOs.OptionToProduct;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("optiontoproduct")]
    public class OptionToProductController : BaseApiController<OptionToProductController>
    {
        private readonly IOptionToProductRepository _cr;
        private readonly IMapper _mapper;

        public OptionToProductController(
            IOptionToProductRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OptionToProductResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<OptionToProductResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<OptionToProductResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<OptionToProductResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<OptionToProductResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<OptionToProductResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<OptionToProductResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<OptionToProductResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OptionToProductResponse>>> PostCategory(OptionToProductRequest request)
        {
            OptionToProduct entity = _mapper.Map<OptionToProduct>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                OptionToProductResponse rm = _mapper.Map<OptionToProductResponse>(insertResult);
                return new WebApiResponse<OptionToProductResponse>(true, "Success", rm);
            }

            return new WebApiResponse<OptionToProductResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OptionToProductResponse>>> PutCategory(int id, OptionToProductRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                OptionToProduct entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    OptionToProductResponse rm = _mapper.Map<OptionToProductResponse>(updateResult);
                    return new WebApiResponse<OptionToProductResponse>(true, "Success", rm);
                }

                return new WebApiResponse<OptionToProductResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}