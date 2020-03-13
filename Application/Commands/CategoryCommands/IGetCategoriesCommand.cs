using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CategoryCommands
{
    public interface IGetCategoriesCommand : ICommandResponse<IEnumerable<CategoryDto>>
    {
    }
}
