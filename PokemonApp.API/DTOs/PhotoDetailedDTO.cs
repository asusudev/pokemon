using System;

namespace PokemonApp.API.DTOs
{
    public class PhotoDetailedDTO
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsPrimary { get; set; }
    }
}