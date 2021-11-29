using System.ComponentModel.DataAnnotations.Schema;

namespace NewWebAPIdotnet6.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
    }
}

