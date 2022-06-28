using System.ComponentModel.DataAnnotations;

namespace CommanderApi.DTOs
{
    public class CommandUpdateDto
    {
        //NOTE: Id is not gonna be provided by the client, its auto-incremented by the database sqlserver
        // public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        [MaxLength(100)]
        public string Platform {get; set;}
   }  
}