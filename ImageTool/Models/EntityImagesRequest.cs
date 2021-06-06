using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ImageTool.Models
{
    public class EntityImagesRequest : IRequest<ImagesResponse>
    {
        public int EntityId { get; set; }
    }
}
