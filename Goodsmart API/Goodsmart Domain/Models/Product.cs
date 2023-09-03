using Goodsmart_Domain.Constants;
using Goodsmart_Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodsmart_Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string? ImgUrl { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(255)]
        public string SellerName { get; set; }

        [Required]
        [EnumDataType(typeof(Category), ErrorMessage = "Invalid Category")]
        public Category Category { get; set; }

        [Required]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31")]
        public DateTime ProductionDate { get; set; }

        [ExpiryDateValidation(nameof(ProductionDate))]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31")]
        public DateTime? ExpiryDate { get; set; }



    
    }

}
