using CommanderApi.DTOs;
using CommanderApi.Models;
namespace CommanderApi.Data
{
    public class MockCommanderRepository : ICommanderRepository
    {
        public IEnumerable<Command> GetCommands()
        {
            var commands = new List<Command>
            {
               new Command {
               Id = 0,
               Description = "Create Dotnet WebApi Project",
               Line = "dotnet new webapi -n projectName",
               Platform = "cross platform"
               },
               new Command {
                  Id = 1,
                  Description = "create initial package.json for javascript project",
                  Line = "npm init -y",
                  Platform = "cross platform"
               },
               new Command {
                  Id = 2,
                  Description = "run react app",
                  Line = "npm run start",
                  Platform = "cross platform"
               }
            };
            return commands;

        }

        public Command GetCommandById(int id)
        {
            return new Command
            {
                Id = 0,
                Description = "Create Dotnet WebApi Project",
                Line = "dotnet new webapi -n projectName",
                Platform = "cross platform"
            };
        }

      public void CreateCommand(Command command )
      {
         throw new NotImplementedException();
      }

      public void UpdateCommand(Command command)
      {
         throw new NotImplementedException();
      }

      public void DeleteCommand(Command command)
      {
         throw new NotImplementedException();
      }

      public bool SaveChanges()
      {
         throw new NotImplementedException();
      }
   }

}