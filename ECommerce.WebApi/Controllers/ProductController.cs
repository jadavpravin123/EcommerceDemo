using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Data.Entities;
using ECommerce.Sevice.Interface;
using ECommerce.Sevice.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("GetProductCaltegory")]
        public async Task<IActionResult> GetProductCaltegory()
        {
            return GenerateResponse(await _productService.GetProductCaltegory());
        }
        [HttpGet]
        [Route("GetAttributeLookup")]
        public async Task<IActionResult> GetAttributeLookup(int id)
        {
            return GenerateResponse(await _productService.GetAttributeLookup(id));
        }

        [HttpPost]
        [Route("AddeditProduct")]
        public async Task<IActionResult> AddEditProduct(productDTO objProduct)
        {
            return GenerateResponse(await _productService.AddEditProduct(objProduct));
        }
        [HttpGet]
        [Route("getAllProducts")]
        public async Task<IActionResult> getAllProducts(int pageNo, int pageSize, string sortOrder)
        {
            return GenerateResponse(await _productService.GetAllProducts(pageNo, pageSize, sortOrder));
        }
        [HttpGet]
        [Route("GetProductCount")]
        public async Task<IActionResult> GetProductCount()
        {
            return GenerateResponse(await _productService.GetProductCount());
        }
        [HttpGet]
        [Route("GetProductid")]
        public async Task<IActionResult> GetProductid(int id)
        {
            return GenerateResponse(await _productService.GetProductid(id));
        }
    }
}
