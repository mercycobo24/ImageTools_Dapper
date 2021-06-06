using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorObjects
{
      public interface IHandlerProvider
    {
        IRequestHandler<TRequest, TResponse> ProvideHandler<TRequest, TResponse>();
    }

}
