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
    public class ProductService : IProductService
    {
        private readonly IOptions<SqlConnectionFactory> _sqlConnectionFactory;

        public ProductService(IOptions<SqlConnectionFactory> sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<ExecutionResult<List<ProductCategory>>> GetProductCaltegory()
        {
            return new ExecutionResult<List<ProductCategory>>(() =>
            {
                var CategoryList = _sqlConnectionFactory.Value.CreateConnection().Query<ProductCategory>("select * from ProductCategory").ToList();
                return CategoryList;
            });
        }

        public async Task<ExecutionResult<List<ProductAttributeLookup>>> GetAttributeLookup(int id)
        {
            return new ExecutionResult<List<ProductAttributeLookup>>(() =>
            {
                var CategoryList = _sqlConnectionFactory.Value.CreateConnection().Query<ProductAttributeLookup>("select * from ProductAttributeLookup where ProdCatId =" + id).ToList();
                return CategoryList;
            });
        }
        public async Task<ExecutionResult<bool>> AddEditProduct(productDTO model)
        {
            return new ExecutionResult<bool>(() =>
            {
                if (!string.IsNullOrEmpty(model.ProdName))
                {
                    if (model.ProductId == 0)
                    {
                        model.DATAOPMODE = 1;
                    }
                    else
                    {
                        model.DATAOPMODE = 2;
                    }
                    var dictionaryParameters = new Dictionary<string, object>
                    {

                      { "@productid",model.ProductId},
                       { "@prodcatid", model.ProdCatId },
                       { "@prodname", model.ProdName },
                       { "@proddescription", model.ProdDescription },
                       { "@attributeid", model.AttributeId },
                       { "@attributevalue", model.AttributeValue },
                        { "@DATAOPMODE", model.DATAOPMODE }

                     };
                    var parameters = new DynamicParameters(dictionaryParameters);

                    var productdata = _sqlConnectionFactory.Value.CreateConnection().Query<productDTO>("sp_InsertUpdateProduct", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
                return true;
            });
        }

        public async Task<ExecutionResult<List<productDTO>>> GetAllProducts(int pageNo, int pageSize, string sortOrder)
        {
            return new ExecutionResult<List<productDTO>>(() =>
            {
                var dictionaryParameters = new Dictionary<string, object>
                {
                  { "@pageNo", pageNo } ,
                  { "@pageSize", pageSize } ,
                  { "@sortOrder", sortOrder }
                };
                var parameters = new DynamicParameters(dictionaryParameters);
                var productList = _sqlConnectionFactory.Value.CreateConnection().Query<productDTO>("sp_GetAllProduct", parameters, commandType: CommandType.StoredProcedure).ToList();
                return productList;
            });
        }

        public async Task<ExecutionResult<int>> GetProductCount()
        {
            return new ExecutionResult<int>(() =>
            {
                var CategoryList = _sqlConnectionFactory.Value.CreateConnection().Query<int>("select count(*) from Product").FirstOrDefault();
                return CategoryList;
            });
        }
        public async Task<ExecutionResult<productDTO>> GetProductid(int id)
        {
            return new ExecutionResult<productDTO>(() =>
            {
                var ProductEdit = _sqlConnectionFactory.Value.CreateConnection().Query<productDTO>("select * from View_GetEditid where ProductId =" + id).FirstOrDefault();
                return ProductEdit;
            });
        }
    }
}
