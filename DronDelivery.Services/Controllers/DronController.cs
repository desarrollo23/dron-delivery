using DronDelivery.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DronDelivery.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DronController : ControllerBase
    {
        private IDronHandler _dronHandler;

        public DronController(IDronHandler dronHandler)
        {
            _dronHandler = dronHandler;
        }

        [HttpGet("delivery")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                await _dronHandler.Operate();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok();
        }
    }
}
