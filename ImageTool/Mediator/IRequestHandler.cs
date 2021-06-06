using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediatorObjects
{ 
    public interface IRequestHandler<TRequest, TResponse>
    {
         Task<TResponse>  Handle(TRequest query);
    }
}

    
