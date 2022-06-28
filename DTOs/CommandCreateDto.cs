namespace CommanderApi.DTOs
{
    public class CommandCreateDto
    {
        //NOTE: Id is not gonna be provided by the client, its auto-incremented by the database sqlserver
        // public int Id { get; set; }
        public string Description { get; set; }
        public string Line { get; set; }
        public string Platform {get; set;}
   }  
}