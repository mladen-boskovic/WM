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
    public class EfGetProductCommand : BaseEfCommand, IGetProductCommand
    {
        public EfGetProductCommand(WmContext context) : base(context)
        {
        }

        public ProductDto Execute(int request)
        {
            var product = Context.PRODUCT.Find(request);

            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
                ProductId = product.PRODUCT_ID,
                Name = product.NAME,
                Description = product.DESCRIPTION,
                Price = product.PRICE,
                CategoryId = product.CATEGORY_ID,
                CategoryName = product.CATEGORY.NAME,
                ManufacturerId = product.MANUFACTURER_ID,
                ManufacturerName = product.MANUFACTURER.NAME,
                SupplierIds = product.PRODUCT_SUPPLIER.Select(ps => ps.SUPPLIER_ID).ToList(),
                SupplierNames = product.PRODUCT_SUPPLIER.Select(ps => ps.SUPPLIER.NAME).ToList()
            };
        }
    }
}
