using Application.Commands.ProductCommands;
using Application.DTOs.InsertUpdateDTOs;
using Application.Exceptions;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.ProductCommands
{
    public class EfAddProductCommand : BaseEfCommand, IAddProductCommand
    {
        public EfAddProductCommand(WmContext context) : base(context)
        {
        }

        public void Execute(InsertUpdateProductDto request)
        {
            if(Context.PRODUCT.Any(p => p.NAME.Trim().ToLower() == request.Name.Trim().ToLower()))
            {
                throw new EntityAlreadyExistsException("Product");
            }

            Context.PRODUCT.Add(new PRODUCT
            {
                NAME = request.Name,
                DESCRIPTION = request.Description,
                PRICE = request.Price,
                CATEGORY_ID = request.CategoryId,
                MANUFACTURER_ID = request.ManufacturerId,
                PRODUCT_SUPPLIER = request.SupplierIds.Select(supplierId => new PRODUCT_SUPPLIER { 
                    PRODUCT_ID = request.ProductId,
                    SUPPLIER_ID = supplierId
                }).ToList()
            });

            Context.SaveChanges();
        }
    }
}
