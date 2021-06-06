using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageTool.Models
{
    public class EntityCommand : IRequest<ImagesCounterResponse>
    {
        public string EntityName { get; set; }
    }
}
