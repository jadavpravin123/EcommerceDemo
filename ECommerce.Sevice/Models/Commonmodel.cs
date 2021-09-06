using ECommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Sevice.Models
{
    public class productDTO
    {
        public int ProductId { get; set; }
        public string ProdCatId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public int AttributeId { get; set; }
        public string AttributeValue { get; set; }
        public string CategoryName { get; set; }
        public string AttributeName { get; set; }
        public int DATAOPMODE { get; set; }

    }
    public class productcategoryDTO
    {
        public int ProdCatId { get; set; }
        public string CategoryName { get; set; }
        public int DATAOPMODE { get; set; }
    }
}
