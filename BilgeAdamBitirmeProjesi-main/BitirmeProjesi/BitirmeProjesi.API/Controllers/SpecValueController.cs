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
using BitirmeProjesi.Service.Repository.SpecValue;
using BitirmeProjesi.Common.DTOs.SpecValue;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("specvalue")]
    public class SpecValueController : BaseApiController<SpecValueController>
    {
        private readonly ISpecValueRepository _cr;
        private readonly IMapper _mapper;

        public SpecValueController(
            ISpecValueRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<SpecValueResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<SpecValueResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<SpecValueResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<SpecValueResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecValueResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<SpecValueResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<SpecValueResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<SpecValueResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<SpecValueResponse>>> PostCategory(SpecValueRequest request)
        {
            SpecValue entity = _mapper.Map<SpecValue>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                SpecValueResponse rm = _mapper.Map<SpecValueResponse>(insertResult);
                return new WebApiResponse<SpecValueResponse>(true, "Success", rm);
            }

            return new WebApiResponse<SpecValueResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<SpecValueResponse>>> PutCategory(int id, SpecValueRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                SpecValue entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    SpecValueResponse rm = _mapper.Map<SpecValueResponse>(updateResult);
                    return new WebApiResponse<SpecValueResponse>(true, "Success", rm);
                }

                return new WebApiResponse<SpecValueResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}