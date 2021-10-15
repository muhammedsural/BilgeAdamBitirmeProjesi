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
using System.Linq;
using BitirmeProjesi.Service.Repository.Product;
using BitirmeProjesi.Common.DTOs.Product;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Controllers
{
    [Route("Product")]
    public class ProductController : BaseApiController<ProductController>
    {
        private readonly IProductRepository _cr;
        private readonly IMapper _mapper;

        public ProductController(
            IProductRepository cr,
            IMapper mapper
        )
        {
            _cr = cr;
            _mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<WebApiResponse<List<ProductResponse>>>> Get()
        {
            MemberResponse currentUser = WorkContext.CurrentUser;
            //using Microsoft.EntityFrameworkCore;
            var categoryResult = _mapper.Map<List<ProductResponse>>(await _cr.TableNoTracking.ToListAsync());
            if (categoryResult.Count > 0)
            {
                return new WebApiResponse<List<ProductResponse>>(true, "Success", categoryResult);
            }

            return new WebApiResponse<List<ProductResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductResponse>>> Get(int id)
        {
            var categoryResult = _mapper.Map<ProductResponse>(await _cr.GetById(id));
            if (categoryResult != null)
            {
                return new WebApiResponse<ProductResponse>(true, "Success", categoryResult);
            }

            return new WebApiResponse<ProductResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<ProductResponse>>> Post(ProductRequest request)
        {
            Product entity = _mapper.Map<Product>(request);
            var insertResult = await _cr.Add(entity);
            if (insertResult != null)
            {
                ProductResponse rm = _mapper.Map<ProductResponse>(insertResult);
                return new WebApiResponse<ProductResponse>(true, "Success", rm);
            }

            return new WebApiResponse<ProductResponse>(false, "Error");
        }

        [HttpPost("ShopGrid")]
        public async Task<ActionResult<WebApiResponse<List<ProductResponse>>>> ShopGrid(ShopGridRequestModelDTO request)
        {
            IQueryable<Product> table;
            table = _cr.Table.AsQueryable();
            if (request.BrandId != 0)
                table = table.Where(i => i.brandId == request.BrandId);
            if (request.CategoryId != 0)
                table = table.Where(i => i.categoryId == request.CategoryId);
            if (request.Sort == 0)
                table = table.OrderBy(i => i.name);
            else if (request.Sort == 1)
                table = table.OrderBy(i => i.price);
            else if (request.Sort == 2)
                table = table.OrderByDescending(i => i.price);

            table = table.Skip(request.Page*6).Take(6);
            if (table.Count() > 0)
            {
                List<ProductResponse> rm = _mapper.Map<List<ProductResponse>>(table);
                return new WebApiResponse<List<ProductResponse>>(true, "Success", rm);
            }

            return new WebApiResponse<List<ProductResponse>>(false, "Error");
        }

        //http://localhost:5000/category/0ac17b49-98fb-41ea-949f-35c676ea0725
        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductResponse>>> Put(int id, ProductRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Product entity = await _cr.GetById(id);
                if (entity == null)
                    return NotFound();
                //Eğer request'ten gelen data varsa onu veritabanında günceller, request'ten gelen data yoksa veritabanındakini tutar.
                _mapper.Map(request, entity);

                var updateResult = await _cr.Update(entity);
                if (updateResult != null)
                {
                    ProductResponse rm = _mapper.Map<ProductResponse>(updateResult);
                    return new WebApiResponse<ProductResponse>(true, "Success", rm);
                }

                return new WebApiResponse<ProductResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<ProductResponse>>> Delete(int id)
        {
          
            try
            {
               var returnBool = await _cr.Remove(id);
                if (returnBool == true)
                    return new WebApiResponse<ProductResponse>(true, "Success");

                return new WebApiResponse<ProductResponse>(false, "Error");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}