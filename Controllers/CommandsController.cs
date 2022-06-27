using CommanderApi.Models;
using CommanderApi.Data;
using Microsoft.AspNetCore.Mvc;
namespace CommanderApi.Controllers
{
   [ApiController]
   [Route("api/commands")]
   public class CommandsController : ControllerBase
   {
      private readonly ICommanderRepository _CommandRepo;
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

// @"Data Source=(localdb)\ProjectModels;Initial Catalog=EFCoreGraduation;Integrated Security=True"

// ,
//   // "ConnectionStrings": {
//   //   "CommanderConnection" : "Server=DESKTOP-E7G0UOF;Initial Catalog=CommanderDB;User ID=CommanderAPI;Password=01283233951;"
//   // }