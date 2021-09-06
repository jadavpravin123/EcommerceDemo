using ECommerce.Data.Entities;
using ECommerce.Sevice.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static ECommerce.Sevice.Helper.ServiceResponse;

namespace ECommerce.Sevice.Interface
{
    public interface IProductService
    {
        Task<ExecutionResult<List<ProductCategory>>> GetProductCaltegory();
        Task<ExecutionResult<List<ProductAttributeLookup>>> GetAttributeLookup(int id);
        Task<ExecutionResult<bool>> AddEditProduct(productDTO model);
        Task<ExecutionResult<List<productDTO>>> GetAllProducts(int pageNo, int pageSize, string sortOrder);
        Task<ExecutionResult<int>> GetProductCount();
        Task<ExecutionResult<productDTO>> GetProductid(int id);
    }
}
