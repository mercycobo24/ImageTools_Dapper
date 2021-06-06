using ImageTool;
using ImageTool.Handlers;
using ImageTool.Models;
using Infrastructure;
using MediatorObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageTool
{
    public class  IRequest 
    {
        private readonly static Dictionary<Type, Type> _handlers = new Dictionary<Type, Type>()
         {
                { typeof(ImagesRequest), typeof(ImagesHandler) }
         };
        private readonly ServiceFactory _serviceFactory;
       public IRequest(ServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }
       
        public Task<TResponse> Dispatch<TRequest, TResponse>(TRequest request)
        {
            var handler = this.GetHandlerByRequest<TRequest, TResponse>();
            return handler.Handle(request);
        }

        private IRequestHandler<TRequest, TResponse> GetHandlerByRequest<TRequest, TResponse>()
        {
            Type requestType = typeof(TRequest);
            IRequestHandler<TRequest, TResponse> handler = null;
            if (!_handlers.ContainsKey(requestType)) 
            {
                throw new ApplicationException($"Handler for query {requestType} is not registered");
            }
            Type handlerType = _handlers[requestType];
            handler =(IRequestHandler < TRequest, TResponse > )_serviceFactory.GetInstance(handlerType);
          
            return handler as IRequestHandler<TRequest, TResponse>;
        }

    }
}
