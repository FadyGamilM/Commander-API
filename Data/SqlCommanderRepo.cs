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

      public void UpdateCommand(Command command)
      {
         // Do nothing because we actually don't need to do nothing the automapper will track the DbContext object 
         // and .SaveChanges() will perform the changes into the DB
      }

      public void DeleteCommand(Command command)
      {
         if (command == null)
         {
            throw new ArgumentNullException(nameof(command));
         }
         this._context.Commands.Remove(command);
      }

      public bool SaveChanges()
      {
         // _Context.SaveChanges() will return int, so to convert it into bool use ">=0"
         return (this._context.SaveChanges() >= 0);
      }
   }
} 