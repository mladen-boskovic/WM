using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public string CategoryName { get; set; }
        public string ManufacturerName { get; set; }
        public IEnumerable<string> SupplierNames { get; set; }
        public IEnumerable<int> SupplierIds { get; set; }
    }
}
