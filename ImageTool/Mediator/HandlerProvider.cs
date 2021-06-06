using System;
using System.Collections.Generic;
using System.Text;
using ImageTool.Handlers;
using ImageTool.Models;
using Infrastructure;
using MediatorObjects;

namespace MediatorObjects
{
    public class HandlerProvider : IHandlerProvider
    {
       
        private static Dictionary<Type, Type> _handlers = new Dictionary<Type, Type>()
         {
                { typeof(ImagesRequest), typeof(ImagesHandler) }
         };

        public IRequestHandler<TRequest, TResponse> ProvideHandler<TRequest, TResponse>()
        {
            Type requestType = typeof(TRequest);

            Type responseType = typeof(TResponse);
            IRequestHandler<TRequest, TResponse> handler = null;
             if (!_handlers.ContainsKey(requestType))
                {
                    throw new ApplicationException($"Handler for query {requestType} is not registered");
                 }
                Type handlerType = _handlers[requestType];

                handler = (IRequestHandler<TRequest, TResponse>) Activator.CreateInstance(handlerType);

                return handler;
            }
    }
}
