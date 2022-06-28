using CommanderApi.Models;
using CommanderApi.DTOs;
using AutoMapper;
namespace CommanderApi.Profiles
{
   public class CommandsProfile : Profile
   {
      public CommandsProfile()
      {
         // Source => Command
         // Target => CommandReadDto
         CreateMap<Command, CommandReadDto>();

         // Source => CommandCreateDto 
         // Target => Command
         CreateMap<CommandCreateDto, Command>();

         //* for put request
         // Source => CommandUpdateDto
         // Target => Command
         CreateMap<CommandUpdateDto, Command>();

         //* for patch request
         // Source => Command
         // Target => CommandUpdateDto
         CreateMap<Command, CommandUpdateDto>();
      }
      
   }
}