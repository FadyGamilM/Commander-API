using CommanderApi.Models;
using CommanderApi.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CommanderApi.DTOs;
using Microsoft.AspNetCore.JsonPatch;

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
      
      /*//! -------------------------- update a command (PUT) -------------------------- */
      [HttpPut("{id}")]
      public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
      {
         //* we first retrieve this Command instance from DB using DbContext
         var command = this._CommandRepo.GetCommandById(id);
         //* if this command is not found, so return NotFound() response with 404
         if (command == null)
         {
            return NotFound();
         }
         // map the recieved CommandUpdateDto into Command instance
         // notice that previously we have an object that contains data
         // and we need to map it into a new entity type "empty object"
         // Now, we have a 2 filled objects and we need to map them with each others
         this._mapper.Map(commandUpdateDto, command); // (FROM, TO)
         // the effect of the mapping here is to update the "command" instance inside the DbContext and track the changes 
         //* => best practices 
         this._CommandRepo.UpdateCommand(command);

         //* save the changes to DB
         this._CommandRepo.SaveChanges();
         
         //* return NoContent with 204
         return NoContent();

      }
      /*//! -------------------------------------------------------------------------- */

      [HttpPatch("{id}")]
      public ActionResult PartialCommandUpdate (int id, JsonPatchDocument<CommandUpdateDto> PatchDoc)
      {
         //* grap this command first and check if its exists in DB
         var command = this._CommandRepo.GetCommandById(id);
         if (command == null)
         {
            return NotFound();
         }
         //* map from the command to CommandUpdateDto data type to be able to apply the patch actions 
         var commandToPatch = this._mapper.Map<CommandUpdateDto>(command);
         //* apply the patch actions
         PatchDoc.ApplyTo(commandToPatch, ModelState);
         //* check the patch action validations
         if (!TryValidateModel(commandToPatch))
         {
            return ValidationProblem(ModelState);
         }
         //* now this instance in the DBContext is holding all the changes, map it to the Command type to send it to the update method of the DbContext
         this._mapper.Map(commandToPatch, command); // they both holding values now
         //* call update
         this._CommandRepo.UpdateCommand(command);
         //* save the changes
         this._CommandRepo.SaveChanges();
         //* return the response as NoContent for 204
         return NoContent();
      }
      
   }
}