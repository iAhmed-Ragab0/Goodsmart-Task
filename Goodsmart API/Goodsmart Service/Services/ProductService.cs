using Goodsmart_Domain.Constants;
using Goodsmart_Domain.Models;
using Goodsmart_Repository._1_IRepositories;
using Goodsmart_Service.DTOs.Product;
using Goodsmart_Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodsmart_Service.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _ProductRepository;

        public ProductService(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }



        public async Task<AddProduct_DTO> AddProductAsync(AddProduct_DTO ProductDTO)
        {


            var NewProduct = new Product() 
            {
                Name= ProductDTO.Name,
                Price = ProductDTO.Price,
                Description= ProductDTO.Description,
                SellerName = ProductDTO.SellerName,               
                Category= (Category)ProductDTO.Category,
                ProductionDate= ProductDTO.ProductionDate,
                ExpiryDate= ProductDTO.ExpiryDate,
            };


            await _ProductRepository.AddAsync(NewProduct);
            return ProductDTO;


           
        }
    }
}
