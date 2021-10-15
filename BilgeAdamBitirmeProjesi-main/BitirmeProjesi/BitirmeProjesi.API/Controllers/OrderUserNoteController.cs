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
using BitirmeProjesi.Service.Repository.OrderUserNote;
using BitirmeProjesi.Common.DTOs.OrderUserNote;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("orderusernote")]
    public class OrderUserNoteController : BaseApiController<OrderUserNoteController>
    {
        private readonly IOrderUserNoteRepository _cr;
        private readonly IMapper _mapper;

        public OrderUserNoteController(
            IOrderUserNoteRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<OrderUserNoteResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<OrderUserNoteResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<OrderUserNoteResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<OrderUserNoteResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderUserNoteResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<OrderUserNoteResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<OrderUserNoteResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<OrderUserNoteResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<OrderUserNoteResponse>>> PostCategory(OrderUserNoteRequest request)
        {
            OrderUserNote entity = _mapper.Map<OrderUserNote>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                OrderUserNoteResponse rm = _mapper.Map<OrderUserNoteResponse>(insertResult);
                return new WebApiResponse<OrderUserNoteResponse>(true, "Success", rm);
            }

            return new WebApiResponse<OrderUserNoteResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<OrderUserNoteResponse>>> PutCategory(int id, OrderUserNoteRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                OrderUserNote entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    OrderUserNoteResponse rm = _mapper.Map<OrderUserNoteResponse>(updateResult);
                    return new WebApiResponse<OrderUserNoteResponse>(true, "Success", rm);
                }

                return new WebApiResponse<OrderUserNoteResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}