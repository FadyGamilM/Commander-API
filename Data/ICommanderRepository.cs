using CommanderApi.Models;
namespace CommanderApi.Data
{
    public interface ICommanderRepository
    {
        // list all commands
        IEnumerable<Command> GetCommands();

        // list specific command by id
        Command GetCommandById(int id);

    }
}