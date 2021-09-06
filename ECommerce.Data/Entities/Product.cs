﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ECommerce.Data.Entities
{
    public partial class Product
    {
        public long ProductId { get; set; }
        public int ProdCatId { get; set; }
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }

        public virtual ProductCategory ProdCat { get; set; }
    }
}
