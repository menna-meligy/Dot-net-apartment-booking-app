using System.ComponentModel.DataAnnotations;

namespace otthanbazar.Data
{
    public class Advertisement
    {

        [Required]
        public int Id { get; set; }

        public string Description { get; set; }

        public int CityId { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public int BuildDate { get; set; }

        [Required]
        public int? HalfRoom { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Room { get; set; }
        [Required]
        public int Size { get; set; }

        public AdvertisementType AdvertisementType { get; set; }
        public City City { get; set; }
    }
}
