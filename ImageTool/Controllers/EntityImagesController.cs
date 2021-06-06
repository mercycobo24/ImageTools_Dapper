using ImageTool.Filters;
using ImageTool.Infrastructure;
using ImageTool.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace ImageTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityImagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EntityImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Posts

        [ProducesResponseType(typeof(ImagesCounterResponse), 200)]
        [Route("AddEntity")]
        [HttpPost]
        public async Task<IActionResult> AddEntity([FromBody] EntityCommand entityCommand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
              
                var res = await _mediator.Send(entityCommand);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [ProducesResponseType(typeof(ImagesCounterResponse), 200)]
        [HttpPost]
        [Route("AddOneImage")]
        public async Task<IActionResult> AddOneImage([FromBody] EntityImageCommand entityImageCommand)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var res = await _mediator.Send(entityImageCommand);
                return Ok(res);
            }
           catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(ImagesCounterResponse), 200)]
        [HttpPost]
        [Route("AddEntityImages")]
        public async Task<IActionResult> AddEntityImages([FromBody] EntityImagesCommand entityImagesCommand)
        {
            try
            { 
            var res = await _mediator.Send(entityImagesCommand);
            return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion Post

        #region Gets
        /// <returns></returns>
        [ProducesResponseType(typeof(ImagesResponse), 200)]
        [HttpGet("{entityId}")]
        public async Task<IActionResult> GetEntityImages(int entityId)
        {
            try
            { 
                 EntityImagesRequest imagesRequest = new EntityImagesRequest { EntityId = entityId };
                 ImagesResponse res = await _mediator.Send(imagesRequest);
                 return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

    }
}