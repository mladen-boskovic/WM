using Application.Commands.ProductCommands;
using Application.DTOs;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.ProductCommands
{
    public class EfGetProductsCommand : BaseEfCommand, IGetProductsCommand
    {
        public EfGetProductsCommand(WmContext context) : base(context)
        {
        }

        public IEnumerable<ProductDto> Execute()
        {
            var products = Context.PRODUCT.Select(p => new ProductDto
            {
                ProductId = p.PRODUCT_ID,
                Name = p.NAME,
                Description = p.DESCRIPTION,
                Price = p.PRICE,
                CategoryId = p.CATEGORY_ID,
                CategoryName = p.CATEGORY.NAME,
                ManufacturerId = p.MANUFACTURER_ID,
                ManufacturerName = p.MANUFACTURER.NAME,
                SupplierIds = p.PRODUCT_SUPPLIER.Select(ps => ps.SUPPLIER_ID).ToList(),
                SupplierNames = p.PRODUCT_SUPPLIER.Select(ps => ps.SUPPLIER.NAME).ToList()
            }).ToList();

            return products;
        }
    }
}
