using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.SupplierCommands
{
    public interface IGetSuppliersCommand : ICommandResponse<IEnumerable<SupplierDto>>
    {
    }
}
