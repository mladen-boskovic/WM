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
    public class EfEditProductCommand : BaseEfCommand, IEditProductCommand
    {
        private EfDeleteProductSuppliersCommand _deleteProductSuppliers { get; }

        public EfEditProductCommand(WmContext context, EfDeleteProductSuppliersCommand deleteProductSuppliers) : base(context)
        {
            _deleteProductSuppliers = deleteProductSuppliers;
        }

        public void Execute(InsertUpdateProductDto request)
        {
            var product = Context.PRODUCT.Find(request.ProductId);

            if(product.NAME != request.Name)
            {
                if (Context.PRODUCT.Any(p => p.NAME.Trim().ToLower() == request.Name.Trim().ToLower()))
                {
                    throw new EntityAlreadyExistsException("Product");
                }
                product.NAME = request.Name;
            }

            product.DESCRIPTION = request.Description;
            product.PRICE = request.Price;
            product.CATEGORY_ID = request.CategoryId;
            product.MANUFACTURER_ID = request.ManufacturerId;

            _deleteProductSuppliers.Execute(request.ProductId);
            product.PRODUCT_SUPPLIER = request.SupplierIds.Select(supplierId => new PRODUCT_SUPPLIER
            {
                PRODUCT_ID = request.ProductId,
                SUPPLIER_ID = supplierId
            }).ToList();

            Context.SaveChanges();
        }
    }
}
