using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands
{
    public abstract class BaseEfCommand
    {
        protected WmContext Context { get; }

        protected BaseEfCommand(WmContext context)
        {
            Context = context;
        }
    }
}
