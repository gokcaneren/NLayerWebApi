﻿using NLayer.Core.DTOs.Respons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IProductService:IService<Product>
    {
        Task<CustomResponsDto<List<ProductWithCategoryDto>>> GetProductWithCategory();
    }
}
