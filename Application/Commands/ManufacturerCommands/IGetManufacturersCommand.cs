using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ManufacturerCommands
{
    public interface IGetManufacturersCommand : ICommandResponse<IEnumerable<ManufacturerDto>>
    {
    }
}
