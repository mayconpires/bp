    using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BP.Interface.Application.Core.MDR;
using BP.Models.ViewModelExamples.Core.MDR;
using BP.Models.ViewModels.Core.MDR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;

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

        /// <summary>
        /// Obtém as taxas de todas as Adquirentes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MdrGetResposeModel))]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(MdrGetResposeModelExample))]
        public async Task<IActionResult> Get()
        {
            var mdrs = await _mdrService.Obter();

            return Ok(mdrs);
        }

    }
}