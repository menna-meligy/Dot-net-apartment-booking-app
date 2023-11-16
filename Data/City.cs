using System.ComponentModel.DataAnnotations;

namespace otthanbazar.Data
{
    public class City
    {
        public int Id { get; set; }
        [Required, StringLength(4, MinimumLength = 4)]
        public string Zip { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
    }
}
