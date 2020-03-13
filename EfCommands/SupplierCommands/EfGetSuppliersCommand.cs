using Application.Commands.SupplierCommands;
using Application.DTOs;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.SupplierCommands
{
    public class EfGetSuppliersCommand : BaseEfCommand, IGetSuppliersCommand
    {
        public EfGetSuppliersCommand(WmContext context) : base(context)
        {
        }

        public IEnumerable<SupplierDto> Execute()
        {
            var suppliers = Context.SUPPLIER.Select(s => new SupplierDto
            {
                SupplierId = s.SUPPLIER_ID,
                Name = s.NAME
            }).ToList();

            return suppliers;
        }
    }
}
