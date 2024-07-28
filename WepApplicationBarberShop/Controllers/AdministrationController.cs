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
    public class AdministrationController : ControllerBase
    {
        private readonly IBarberService _Service;
        public AdministrationController(IBarberService service)
        {
            this._Service = service;
        }
        [HttpGet("GetPerfils")]
        public async Task<ActionResult<PerfilsResponse>> GetPerfils()
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");            
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.getPerfils();
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
        [HttpGet("GetUsers")]
        public async Task<ActionResult<UsersResponse>> GetUsers()
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.getUsers();
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
        [HttpGet("GetUser/{idUser}")]
        public async Task<ActionResult<UsersResponse>> GetUser(string idUser)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.getUser(idUser);
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
        [HttpGet("DeleteUser/{idUser}")]
        public async Task<ActionResult<CommonResult>> DeleteUser(string idUser)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.deleteUser(idUser);
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
        [HttpPost("CreateUser")]
        public async Task<ActionResult<PerfilsResponse>> CreateUser(CreateUserRequest _request)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.addUserAsync(_request);
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
        [HttpPost("UpdateUser")]
        public async Task<ActionResult<PerfilsResponse>> UpdateUser(UpdateUserRequest _request)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.updateUserAsync(_request);
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

        [HttpGet("GetBarbers")]
        public async Task<ActionResult<BarbersResponse>> GetBarbers()
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.getBarbers();
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
        [HttpGet("GetBarber/{idBarber}")]
        public async Task<ActionResult<BarbersResponse>> GetBarbers(string idBarber)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.getBarber(idBarber);
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
        [HttpGet("DeleteBarber/{idBarber}")]
        public async Task<ActionResult<CommonResult>> DeleteBarbers(string idBarber)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.deleteBarber(idBarber);
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
        [HttpPost("CreateBarber")]
        public async Task<ActionResult<PerfilsResponse>> CreateBarber(CreateBarberRequest _request)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.addBarberAsync(_request);
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
        [HttpPost("UpdateBarber")]
        public async Task<ActionResult<PerfilsResponse>> UpdateBarber(UpdateBarberRequest _request)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.updateBarberAsync(_request);
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
        [HttpGet("GetTurns")]
        public async Task<ActionResult<TurnsResponse>> GetTurns()
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.getTurns();
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
        [HttpPost("CreateTurns")]
        public async Task<ActionResult<PerfilsResponse>> CreateTurns(CreateTurnRequest _request)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.addTurnsAsync(_request);
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
        [HttpPost("RelationBarberTurn")]
        public async Task<ActionResult<CommonResult>> RelationBarberTurn(CreateRelationBarberTurnRequest _request)
        {
            Stopwatch timerProcess = Stopwatch.StartNew();
            Logger.Error($"********* NEW REQUEST *********");
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await this._Service.addRelationBarberTurnAsync(_request);
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
