using Application.Commands.CategoryCommands;
using Application.DTOs;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.CategoryCommands
{
    public class EfGetCategoriesCommand : BaseEfCommand, IGetCategoriesCommand
    {
        public EfGetCategoriesCommand(WmContext context) : base(context)
        {
        }

        public IEnumerable<CategoryDto> Execute()
        {
            var categories = Context.CATEGORY.Select(c => new CategoryDto
            {
                CategoryId = c.CATEGORY_ID,
                Name = c.NAME
            }).ToList();

            return categories;
        }
    }
}
