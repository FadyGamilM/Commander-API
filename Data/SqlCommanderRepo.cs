using CommanderApi.DTOs;
using CommanderApi.Models;
namespace CommanderApi.Data
{
   public class SqlCommanderRepo : ICommanderRepository
   {
      //! we need to use an instance of our DBContext class which is CommanderContext
      //! we defined it as a service in the startup program, so we will use a DI pattern
      private readonly CommanderContext _context;
      public SqlCommanderRepo(CommanderContext context)
      {
         this._context = context;
      }
      public IEnumerable<Command> GetCommands()
      {
         return this._context.Commands.ToList();
      }

      public Command GetCommandById(int id)
      {
         return this._context.Commands.FirstOrDefault(c => c.Id == id);
      }

      public void CreateCommand(Command command)
      {
         if (command == null)
         {
            throw new ArgumentNullException(nameof(command));
         }
         this._context.Commands.Add(command);

      }

      public void UpdateCommand(int id, Command command)
      {
         throw new NotImplementedException();
      }

      public void DeleteCommand(int id)
      {
         throw new NotImplementedException();
      }

      public bool SaveChanges()
      {
         // _Context.SaveChanges() will return int, so to convert it into bool use ">=0"
         return (this._context.SaveChanges() >= 0);
      }
   }
} 