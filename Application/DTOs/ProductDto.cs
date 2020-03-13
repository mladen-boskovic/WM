using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProductDto
    {
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }

        [Display(Name = "Manufacturer ID")]
        public int ManufacturerId { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Manufacturer Name")]
        public string ManufacturerName { get; set; }

        [Display(Name = "Supplier Names")]
        public IEnumerable<string> SupplierNames { get; set; }

        [Display(Name = "Supplier IDs")]
        public IEnumerable<int> SupplierIds { get; set; }
    }
}
