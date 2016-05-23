using System.Collections.Generic;
namespace App.Models
{
    public class PayloadItemDto
    {
        public string Country { get; set; }
        public string Description { get; set; }
        public bool? Drm { get; set; }
        public int? EpisodeCount { get; set; }
        public string Genre { get; set; }
        public ImageDto Image { get; set; }
        public string Language { get; set; }
        public NextEpisodeDto NextEpisode { get; set; }
        public string PrimaryColour { get; set; }
        public IEnumerable<SeasonDto> Seasons { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string TvChannel { get; set; }
    }
}