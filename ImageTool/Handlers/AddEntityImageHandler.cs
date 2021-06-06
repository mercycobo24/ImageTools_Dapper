using DataAccess;
using ImageTool.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageTool.Handlers
{
    public class AddEntityImageHandler : IRequestHandler<EntityImageCommand, ImagesCounterResponse>
    {
        ISqlDapperDataAccess _sqlDapperDataAccess;
        public AddEntityImageHandler(ISqlDapperDataAccess sqlDapperDataAccess)
        {
            _sqlDapperDataAccess = sqlDapperDataAccess;
        }

        public async Task<ImagesCounterResponse> Handle(EntityImageCommand request, CancellationToken cancellationToken)
        {
            int recordsAffected = await _sqlDapperDataAccess.ExecuteCommand("dbo.InsertImage", request);
            ImagesCounterResponse images = new ImagesCounterResponse { InsertedRecords = recordsAffected };
            return images;
        }
    }
}
