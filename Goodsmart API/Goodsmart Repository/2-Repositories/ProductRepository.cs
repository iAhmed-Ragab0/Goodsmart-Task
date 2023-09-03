using Goodsmart_Domain.Models;
using Goodsmart_Repository._1_IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodsmart_Repository._2_Repositories
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

    }
}
