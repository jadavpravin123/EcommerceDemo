using Dapper;
using ECommerce.Data.DataContext;
using ECommerce.Data.Entities;
using ECommerce.Sevice.Interface;
using ECommerce.Sevice.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECommerce.Sevice.Helper.ServiceResponse;

namespace ECommerce.Sevice.service
{
    public class ProductcategoryService : IProductcategoryService
    {
        private readonly IOptions<SqlConnectionFactory> _sqlConnectionFactory;

        public ProductcategoryService(IOptions<SqlConnectionFactory> sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<ExecutionResult<List<ProductCategory>>> GetProductCaltegory()
        {
            return new ExecutionResult<List<ProductCategory>>(() =>
            {
                var CategoryList = _sqlConnectionFactory.Value.CreateConnection().Query<ProductCategory>("select * from ProductCategory order by ProdCatId desc").ToList();
                return CategoryList;
            });
        }
        public async Task<ExecutionResult<ProductCategory>> GetProductCategoryId(int id)
        {
            return new ExecutionResult<ProductCategory>(() =>
            {
                var Categorydata = _sqlConnectionFactory.Value.CreateConnection().Query<ProductCategory>("select * from ProductCategory where ProdCatId =" + id).FirstOrDefault();
                return Categorydata;
            });
        }
        public async Task<ExecutionResult<bool>> AddEditProductcategory(productcategoryDTO model)
        {
            return new ExecutionResult<bool>(() =>
            {
                if (!string.IsNullOrEmpty(model.CategoryName))
                {
                    if (model.ProdCatId == 0)
                    {
                        model.DATAOPMODE = 1;
                    }
                    else
                    {
                        model.DATAOPMODE = 2;
                    }
                    var dictionaryParameters = new Dictionary<string, object>
                    {
                       { "@prodcatid", model.ProdCatId },
                       { "@categoryname", model.CategoryName },
                        { "@DATAOPMODE", model.DATAOPMODE }

                     };
                    var parameters = new DynamicParameters(dictionaryParameters);

                    var productcategorydata = _sqlConnectionFactory.Value.CreateConnection().Query<productcategoryDTO>("sp_InsertUpdateProductcategory", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
                return true;
            });
        }
    }
}
