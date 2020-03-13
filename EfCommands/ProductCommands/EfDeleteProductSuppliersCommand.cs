using Application.Commands.ProductCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.ProductCommands
{
    public class EfDeleteProductSuppliersCommand : BaseEfCommand, IDeleteProductSuppliersCommand
    {
        public EfDeleteProductSuppliersCommand(WmContext context) : base(context)
        {
        }

        public void Execute(int request)
        {
            var productSuppliers = Context.PRODUCT_SUPPLIER.Where(ps => ps.PRODUCT_ID == request);
            Context.PRODUCT_SUPPLIER.RemoveRange(productSuppliers);
            Context.SaveChanges();
        }
    }
}
