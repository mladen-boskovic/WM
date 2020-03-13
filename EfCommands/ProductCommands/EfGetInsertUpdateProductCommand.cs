using Application.Commands.ProductCommands;
using Application.DTOs.InsertUpdateDTOs;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.ProductCommands
{
    public class EfGetInsertUpdateProductCommand : BaseEfCommand, IGetInsertUpdateProductCommand
    {
        public EfGetInsertUpdateProductCommand(WmContext context) : base(context)
        {
        }

        public InsertUpdateProductDto Execute(int request)
        {
            var product = Context.PRODUCT.Find(request);

            if(product == null)
            {
                return null;
            }

            return new InsertUpdateProductDto
            {
                ProductId = product.PRODUCT_ID,
                Name = product.NAME,
                Description = product.DESCRIPTION,
                Price = product.PRICE,
                CategoryId = product.CATEGORY_ID,
                ManufacturerId = product.MANUFACTURER_ID,
                SupplierIds = product.PRODUCT_SUPPLIER.Select(ps => ps.SUPPLIER_ID).ToArray()
            };
        }
    }
}
