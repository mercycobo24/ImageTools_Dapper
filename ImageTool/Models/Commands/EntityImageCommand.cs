using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ImageTool.Models
{
    public class EntityImageCommand : IRequest<ImagesCounterResponse>
    {

        public int EntityId { get; set; }

        public string URL { get; set; }
    }
}
