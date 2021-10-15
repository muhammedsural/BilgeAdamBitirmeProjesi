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
using BitirmeProjesi.Service.Repository.ProductComment;
using BitirmeProjesi.Common.DTOs.ProductComment;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("productcomment")]
    public class ProductCommentController : BaseApiController<ProductCommentController>
    {
        private readonly IProductCommentRepository _cr;
        private readonly IMapper _mapper;

        public ProductCommentController(
            IProductCommentRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductCommentResponse>>>> GetCategories()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<ProductCommentResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<ProductCommentResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<ProductCommentResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductCommentResponse>>> GetCategory(int id)
        {
            var categoryResult = _mapper.Map<ProductCommentResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<ProductCommentResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<ProductCommentResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ProductCommentResponse>>> PostCategory(ProductCommentRequest request)
        {
            ProductComment entity = _mapper.Map<ProductComment>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                ProductCommentResponse rm = _mapper.Map<ProductCommentResponse>(insertResult);
                return new WebApiResponse<ProductCommentResponse>(true, "Success", rm);
            }

            return new WebApiResponse<ProductCommentResponse>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductCommentResponse>>> PutCategory(int id, ProductCommentRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                ProductComment entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    ProductCommentResponse rm = _mapper.Map<ProductCommentResponse>(updateResult);
                    return new WebApiResponse<ProductCommentResponse>(true, "Success", rm);
                }

                return new WebApiResponse<ProductCommentResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}