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
    public class AddEntityHandler : IRequestHandler<EntityCommand, ImagesCounterResponse>
    {
        readonly ISqlDapperDataAccess _sqlDapperDataAccess;
        public AddEntityHandler(ISqlDapperDataAccess sqlDapperDataAccess)
        {
            _sqlDapperDataAccess = sqlDapperDataAccess;
        }

        public async Task<ImagesCounterResponse> Handle(EntityCommand request, CancellationToken cancellationToken)
        {
            int recordsAffected = await _sqlDapperDataAccess.ExecuteCommand("dbo.InsertEntity", request);
            ImagesCounterResponse images = new ImagesCounterResponse { InsertedRecords = recordsAffected };
            return images;
        }
    }
}
