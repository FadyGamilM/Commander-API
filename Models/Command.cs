using System.ComponentModel.DataAnnotations;

namespace CommanderApi.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        [MaxLength(100)]
        public string Platform { get; set; }
    }

}