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
using BitirmeProjesi.Service.Repository.Maillist;
using BitirmeProjesi.Common.DTOs.Maillist;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("maillist")]
    public class MaillistController : BaseApiController<MaillistController>
    {
        private readonly IMaillistRepository _cr;
        private readonly IMapper _mapper;

        public MaillistController(
            IMaillistRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<MaillistResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<MaillistResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<MaillistResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<MaillistResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<MaillistResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<MaillistResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<MaillistResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<MaillistResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<MaillistResponse>>> PostCategory(MaillistRequest request)
        {
            Maillist entity = _mapper.Map<Maillist>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                MaillistResponse rm = _mapper.Map<MaillistResponse>(insertResult);
                return new WebApiResponse<MaillistResponse>(true, "Success", rm);
            }

            return new WebApiResponse<MaillistResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<MaillistResponse>>> PutCategory(int id, MaillistRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Maillist entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    MaillistResponse rm = _mapper.Map<MaillistResponse>(updateResult);
                    return new WebApiResponse<MaillistResponse>(true, "Success", rm);
                }

                return new WebApiResponse<MaillistResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}