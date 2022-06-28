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

        //* update a command by id
        void UpdateCommand(int id, Command command);

        //* delete a command by id 
        void DeleteCommand(int id);

      bool SaveChanges();
   }
}