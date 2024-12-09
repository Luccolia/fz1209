using System.Text.Json.Serialization;

namespace backend1209.Models
{
    public partial class Movie
    {
        public int MovieId { get; set; }
        public string? Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? FilmTypeId { get; set; }
        public int? ActorId { get; set; }
        [JsonIgnore]

        public virtual Actor? Actor { get; set; }

        [JsonIgnore]

        public virtual FilmType? FilmType { get; set; }

    }
}

