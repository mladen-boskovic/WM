using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommandRequest<TRequest>
    {
        void Execute(TRequest request);
    }

    public interface ICommandResponse<Tresponse>
    {
        Tresponse Execute();
    }

    public interface ICommand<TRequest, TResponse>
    {
        TResponse Execute(TRequest request);
    }
}
