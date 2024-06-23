using BCP.Framework.Log;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WepApplicationBarberShop.Models.Common;
using WepApplicationBarberShop.Models.DTO.Request;
using WepApplicationBarberShop.Models.DTO.Response;
using WepApplicationBarberShop.Services.Service;

namespace WepApplicationBarberShop.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IBarberService _Service;
        public ClientController(IBarberService service)
        {
            this._Service = service;
        }
        [HttpGet("GetClients")]
        public async Task<ActionResult<PerfilsResponse>> GetClients()
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.getClients();
                    timerProcess.Stop();
                    Logger.Error($"RESPONSE Sent, processTime:[" + timerProcess.Elapsed.ToString() + "] Response Service: " + JsonConvert.SerializeObject(response));
                    return Ok(response);
                }
                else
                    return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("[API]", $"Se generó un error con el servicio => " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("CreateClient")]
        public async Task<ActionResult<CommonResult>> CreateUser(CreateClientRequest _request)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.addClientAsync(_request);
                    timerProcess.Stop();
                    Logger.Error($"RESPONSE Sent, processTime:[" + timerProcess.Elapsed.ToString() + "] Response Service: " + JsonConvert.SerializeObject(response));
                    return Ok(response);
                }
                else
                    return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("[API]", $"Se generó un error con el servicio => " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
