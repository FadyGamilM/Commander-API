using CommanderApi.Models;
using CommanderApi.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CommanderApi.DTOs;

namespace CommanderApi.Controllers
{
   [ApiController]
   [Route("api/commands")]
   public class CommandsController : ControllerBase
   {
      /*//! ---------------- private attributes for injected services ---------------- */
      private readonly ICommanderRepository _CommandRepo;
      private readonly IMapper _mapper;
      /*//! -------------------------------------------------------------------------- */

      /*//! ------------------------------- Constructor ------------------------------ */
      public CommandsController(ICommanderRepository CommandRepo, IMapper mapper)
      {
         this._CommandRepo =CommandRepo;
         this._mapper = mapper;
      }
      /*//! -------------------------------------------------------------------------- */
      
      /*//! ------------------------ Get All Commands Handler ------------------------ */
      [HttpGet]
      public ActionResult<IEnumerable<CommandReadDto>> GetCommands()
      {
         var commands = this._CommandRepo.GetCommands();
         return Ok(this._mapper.Map<IEnumerable<CommandReadDto>>(commands));
      }
      /*//! -------------------------------------------------------------------------- */

      /*//! ------------------------ Get Command By Id Handler ----------------------- */
      [HttpGet("{id}", Name="GetCommandById")]
      public ActionResult<CommandReadDto> GetCommandById (int id)
      {
         var command = this._CommandRepo.GetCommandById(id);
         if (command is null)
         {
            return NotFound();
         }
         // Map<Into_Class_Format>(From_instance_Format)
         return Ok(this._mapper.Map<CommandReadDto>(command));
      }
      /*//! -------------------------------------------------------------------------- */

      /*//! -------------------------- create a new command -------------------------- */
      [HttpPost]
      public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
      {
         // map the recieved CommandCreateDto into Command instance
         var command = this._mapper.Map<Command>(commandCreateDto);
         this._CommandRepo.CreateCommand(command);
         this._CommandRepo.SaveChanges();
         var commandReadDto = this._mapper.Map<CommandReadDto>(command);
         return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);        
      }
      /*//! -------------------------------------------------------------------------- */
   }
}