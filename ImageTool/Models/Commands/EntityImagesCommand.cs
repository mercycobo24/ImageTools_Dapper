using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImageTool.Models
{
    public class EntityImagesCommand : IRequest<ImagesCounterResponse>
    {
        public List<EntityImage> EntityImages { get; set; }
    }

  
}
