using ECommerce.Data.Entities;
using ECommerce.Sevice.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static ECommerce.Sevice.Helper.ServiceResponse;

namespace ECommerce.Sevice.Interface
{
    public interface IProductcategoryService
    {
        Task<ExecutionResult<List<ProductCategory>>> GetProductCaltegory();
        Task<ExecutionResult<ProductCategory>> GetProductCategoryId(int id);
        Task<ExecutionResult<bool>> AddEditProductcategory(productcategoryDTO model);
    }
}
