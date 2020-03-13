using Application.Commands.ManufacturerCommands;
using Application.DTOs;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.ManufacturerCommands
{
    public class EfGetManufacturersCommand : BaseEfCommand, IGetManufacturersCommand
    {
        public EfGetManufacturersCommand(WmContext context) : base(context)
        {
        }

        public IEnumerable<ManufacturerDto> Execute()
        {
            var manufacturers = Context.MANUFACTURER.Select(m => new ManufacturerDto
            {
                ManufacturerId = m.MANUFACTURER_ID,
                Name = m.NAME
            }).ToList();

            return manufacturers;
        }
    }
}
