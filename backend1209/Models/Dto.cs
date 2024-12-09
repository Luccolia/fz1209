namespace backend1209.Models
{
    public class Dto
    {
        public record ActorDto(int ActorId, string ActorName);

        public record CreateActorDto(int ActorId, string ActorName);

        public record UpdateActorDto(int ActorId, string ActorName);
    }
}
