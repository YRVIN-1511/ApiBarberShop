﻿using BCP.Framework.Log;
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
        public async Task<ActionResult<ReservationResponse>> GenerateReservation(ReservationRequest _request)
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

        [HttpGet("GetInformationReservation/{idReservation}")]
        public async Task<ActionResult<InformationReservationResponse>> GetInformationReservation(string idReservation)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.GetInformationReservation(idReservation);
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
        [HttpPost("CreateService")]
        public async Task<ActionResult<CommonResult>> CreateService(ServiceCreateRequest _request)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    if (_request.trace == string.Empty)
                        _request.trace = DateTime.Now.ToString("yyyyMMddssffff");
                    var response = await this._Service.addServiceBarber(_request);
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
        [HttpGet("GetServices")]
        public async Task<ActionResult<ServicesResponse>> GetServices()
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.getServices();
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
        [HttpGet("GetServices/{idService}")]
        public async Task<ActionResult<ServicesResponse>> GetServices(int idService)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.getServices(idService);
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
        [HttpPost("CreateCombo")]
        public async Task<ActionResult<CommonResult>> CreateCombo(ComboCreateRequest _request)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    if (_request.trace == string.Empty)
                        _request.trace = DateTime.Now.ToString("yyyyMMddssffff");
                    var response = await this._Service.addComboBarber(_request);
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
        [HttpGet("GetCombos")]
        public async Task<ActionResult<CombosResponse>> GetCombos()
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.getCombos();
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
        [HttpGet("GetCombos/{idCombo}")]
        public async Task<ActionResult<CombosResponse>> GetCombos(int idCombo)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.getCombos(idCombo);
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
        [HttpPost("PaymentRegister")]
        public async Task<ActionResult<CommonResult>> PaymentRegister(PaymentRegisterRequest _request)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.addRegisterPayment(_request);
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
        [HttpPost("FilterBarbersByService")]

        public async Task<ActionResult<CommonResult>> FilterBarbersByService(FilterBarberByService _request)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.filterBarbersByService(_request);
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
