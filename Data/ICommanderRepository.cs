using CommanderApi.Models;
using CommanderApi.DTOs;
namespace CommanderApi.Data
{
    public interface ICommanderRepository
    {
        //* list all commands
        IEnumerable<Command> GetCommands();

        //* list specific command by id
        Command GetCommandById(int id);

        //* Create a new Command 
        void CreateCommand(Command command);

        //* update a command
        void UpdateCommand(Command command);

        //* delete a command 
        void DeleteCommand(Command command);

      bool SaveChanges();
   }
}