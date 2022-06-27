using Microsoft.EntityFrameworkCore;
using CommanderApi.Models;
namespace CommanderApi.Data
{
   public class CommanderContext : DbContext
   {
      public CommanderContext(DbContextOptions<CommanderContext> opt ) : base(opt)
      {
         
      }

      public DbSet<Command> Commands {get; set;}
   }
}