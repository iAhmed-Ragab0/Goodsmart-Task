using Goodsmart_Domain.Models;
using Goodsmart_Repository._1_IRepositories;
using Goodsmart_Service.DTOs.Product;
using Goodsmart_Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Goodsmart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _ProductService;

        public ProductsController(IProductService productService)
        {
            _ProductService = productService;
        }

        [HttpPost]

        public async Task<IActionResult> Add(AddProduct_DTO ProductDTO)
        {
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }


            try
            {
               var result =  await _ProductService.AddProductAsync(ProductDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException?.Message ?? ex.Message);
            }


        }

    }
}
