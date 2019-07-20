using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BP.Interface.Application.Core.MDR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BP.API.Controllers
{
    [ApiController]
    [Route("mdr")]
    [Produces("application/json")]
    public class MdrController : ControllerBase
    {
        IMdrService _mdrService;

        public MdrController(IMdrService mdrService)
        {
            _mdrService = mdrService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var mdrs = await _mdrService.Obter();

            return Ok(mdrs);
        }

    }
}