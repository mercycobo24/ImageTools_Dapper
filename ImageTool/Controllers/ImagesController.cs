using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageTool.Models;
using MediatorObjects;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageTool
{
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        IRequest _mediator;
        public ImagesController(IRequest mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get UVS URL images
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<Models.ImagesResponse>), 200)]

        [HttpGet("{productCode}")]
        public async Task<IActionResult> GetCloudImages(int productCode)
        {
            ImagesRequest imagesRequest = new ImagesRequest { EntityId = productCode };
           // var t = await _mediator.Dispatch<ImagesRequest, ImagesResponse>(imagesRequest);
            return Ok (await _mediator.Dispatch<ImagesRequest, ImagesResponse>(imagesRequest));
        }


     
    }

}
