﻿using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ProductCommands
{
    public interface IGetProductsCommand : ICommandResponse<IEnumerable<ProductDto>>
    {
    }
}