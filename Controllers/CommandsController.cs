using CommanderApi.Models;
using CommanderApi.Data;
using Microsoft.AspNetCore.Mvc;
namespace CommanderApi.Controllers
{
   [ApiController]
   [Route("api/commands")]
   public class CommandsController : ControllerBase
   {
      public readonly ICommanderRepository _CommandRepo;
      public CommandsController(ICommanderRepository CommandRepo)
      {
         this._CommandRepo =CommandRepo;
      }
      
      [HttpGet]
      public ActionResult<IEnumerable<Command>> GetCommands()
      {
         var commands = this._CommandRepo.GetCommands();
         return Ok(commands);
      }

      [HttpGet("{id}")]
      public ActionResult<Command> GetCommandById (int id)
      {
         var command = this._CommandRepo.GetCommandById(id);
         if (command is null)
         {
            return NotFound();
         }
         return Ok(command);
      }
   }
}