using BCP.Framework.Log;
using Microsoft.AspNetCore.Http;
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
    public class BarberShopController : ControllerBase
    {
        private readonly IBarberService _Service;
        public BarberShopController(IBarberService service)
        {
            this._Service = service;
        }
        [HttpPost("GenerateReservation")]
        public async Task<ActionResult<CommonResult>> GenerateReservation(ReservationRequest _request)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.addReservationAsync(_request);
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
        [HttpPost("GetTimesByBarber")]
        public async Task<ActionResult<AvailableTimesBarberResponse>> GetTimesByBarber(AvailableTimesBarberRequest _request)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.GetAvailableTimesByIdBarber(_request);
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
        [HttpGet("GetAvailableTimesBarbers")]
        public async Task<ActionResult<BarbersResponse>> GetAvailableBarbers(bool available)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.GetAvailableTimesBarbers(available);
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
