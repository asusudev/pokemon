using System;

namespace PokemonApp.API.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsPrimary { get; set; }

        public AppUser AppUser { get; set; }

        public int AppUserId { get; set; }
    }
}