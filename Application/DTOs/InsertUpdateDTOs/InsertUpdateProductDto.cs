using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.InsertUpdateDTOs
{
    public class InsertUpdateProductDto
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name must contain 1-50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "Description must contain 10-250 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01-9999999999.99")]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required")]
        [Range(1, Int64.MaxValue, ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        [Display(Name = "Manufacturer")]
        [Required(ErrorMessage = "Manufacturer is required")]
        [Range(1, Int64.MaxValue, ErrorMessage = "Manufacturer is required")]
        public int ManufacturerId { get; set; }

        [Display(Name = "Supplier/s")]
        [Required(ErrorMessage = "Supplier/s is/are required")]
        [MinLength(1, ErrorMessage = "Product must have at least 1 supplier")]
        public int[] SupplierIds { get; set; }
    }
}
