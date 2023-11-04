﻿using ETicaretAPI.Application.Abtract;
using ETicaretAPI.Application.Repositories.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository,IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetProduct()
        //{
        //    return Ok();
        //}
        [HttpGet]
        public async Task Add()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id = Guid.NewGuid(),Name = "Product1",Price = 100,CreatedDate = DateTime.Now,Stock = 10},
                new(){Id = Guid.NewGuid(),Name = "Product2",Price = 100,CreatedDate = DateTime.Now,Stock = 10 },
                new(){Id = Guid.NewGuid(),Name = "Product3",Price = 100,CreatedDate = DateTime.Now,Stock = 10 } });
            await _productWriteRepository.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productReadRepository.GetByIdAsync(id, false);
            return Ok(product);
        }
    }
}
