using Dapper;
using DataAccess;
using ImageTool.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageTool.Handlers
{
    public class AddEntityImagesHandler : IRequestHandler<EntityImagesCommand, ImagesCounterResponse>
    {
        readonly ISqlDapperDataAccess _sqlDapperDataAccess;
        public AddEntityImagesHandler(ISqlDapperDataAccess sqlDapperDataAccess)
        {
            _sqlDapperDataAccess = sqlDapperDataAccess;
        }
        public async Task<ImagesCounterResponse> Handle(EntityImagesCommand command, CancellationToken cancellationToken)
        {
                var imagesData = GetEntityImages(command);
                int recordsAffected = await _sqlDapperDataAccess.ExecuteCommand("InsertImages",
                    new { images = imagesData.AsTableValuedParameter("UDTImagesTable") });
                ImagesCounterResponse images = new ImagesCounterResponse { InsertedRecords = recordsAffected };

                return images;
           
        }


        private DataTable GetEntityImages(EntityImagesCommand command)
        {
            var output = new DataTable();
            output.Columns.Add("EntityId", typeof(int));
            output.Columns.Add("URL", typeof(string));
            foreach (var c in command.EntityImages)
            {
                
                output.Rows.Add(c.EntityId, c.URL);
            }

            return output;
        }
    }
}
