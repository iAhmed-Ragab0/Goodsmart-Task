using Goodsmart_Domain.Models;
using Goodsmart_Service.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodsmart_Service.IServices
{
    public interface IProductService
    {
        public Task<AddProduct_DTO> AddProductAsync(AddProduct_DTO ProductDTO);

    }
}
