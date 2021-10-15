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
using BitirmeProjesi.Service.Repository.Options;
using BitirmeProjesi.Common.DTOs.Options;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("options")]
    public class OptionsController : BaseApiController<OptionsController>
    {
        private readonly IOptionsRepository _cr;
        private readonly IMapper _mapper;

        public OptionsController(
            IOptionsRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OptionsResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<OptionsResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<OptionsResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<OptionsResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<OptionsResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<OptionsResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<OptionsResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<OptionsResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OptionsResponse>>> PostCategory(OptionsRequest request)
        {
            Options entity = _mapper.Map<Options>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                OptionsResponse rm = _mapper.Map<OptionsResponse>(insertResult);
                return new WebApiResponse<OptionsResponse>(true, "Success", rm);
            }

            return new WebApiResponse<OptionsResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OptionsResponse>>> PutCategory(int id, OptionsRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Options entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    OptionsResponse rm = _mapper.Map<OptionsResponse>(updateResult);
                    return new WebApiResponse<OptionsResponse>(true, "Success", rm);
                }

                return new WebApiResponse<OptionsResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}