using System.ComponentModel.DataAnnotations;

namespace otthanbazar.Models
{
    public class SearchModel
    {
        [Display(Name = "City ID")]
        public int? CityId { get; set; }

        [Display(Name = "City Name")]
        public string CityName { get; set; }

        [Display(Name = "Maximum Price")]
        public decimal? PriceMax { get; set; }

        [Display(Name = "Minimum Price")]
        public decimal? PriceMin { get; set; }

        [Display(Name = "Maximum Rooms")]
        public int? RoomMax { get; set; }

        [Display(Name = "Minimum Rooms")]
        public int? RoomMin { get; set; }

        [Display(Name = "Maximum Size")]
        public int? SizeMax { get; set; }

        [Display(Name = "Minimum Size")]
        public int? SizeMin { get; set; }
    }
}
