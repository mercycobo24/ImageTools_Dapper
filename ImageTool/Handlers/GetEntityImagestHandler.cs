using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess;
using ImageTool.Infrastructure;
using ImageTool.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ImageTool.Handlers
{
    public class EntityImagesRequestHandler : IRequestHandler<EntityImagesRequest, ImagesResponse>
    {
       
        readonly ISqlDapperDataAccess _sqlDapperDataAccess;

        public EntityImagesRequestHandler(ISqlDapperDataAccess sqlDapperDataAccess)
        {
            _sqlDapperDataAccess = sqlDapperDataAccess;
        }

        public async Task<ImagesResponse> Handle(EntityImagesRequest request, CancellationToken cancellationToken)
        {
            var output = await _sqlDapperDataAccess.LoadData<Image, dynamic>("dbo.GetEntityImages", new {request.EntityId });
            ImagesResponse response =  new ImagesResponse { images = output };
            return response;
        }
    }
}
