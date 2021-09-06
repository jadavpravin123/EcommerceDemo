using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Sevice.Interface;
using ECommerce.Sevice.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers
{
    public class ProductCategoryController : BaseController
    {
        private readonly IProductcategoryService _productcategoryService;

        [HttpGet]
        [Route("GetProductCaltegory")]
        public async Task<IActionResult> GetProductCaltegory()
        {
            return GenerateResponse(await _productcategoryService.GetProductCaltegory());
        }
        public ProductCategoryController(IProductcategoryService productcategoryService)
        {
            _productcategoryService = productcategoryService;
        }
        [HttpGet]
        [Route("GetProductCategoryId")]
        public async Task<IActionResult> GetProductCategoryId(int id)
        {
            return GenerateResponse(await _productcategoryService.GetProductCategoryId(id));
        }

        [HttpPost]
        [Route("AddEditProductcategory")]
        public async Task<IActionResult> AddEditProductcategory(productcategoryDTO model)
        {
            return GenerateResponse(await _productcategoryService.AddEditProductcategory(model));
        }
    }
}
