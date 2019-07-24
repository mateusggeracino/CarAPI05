using System.ComponentModel.DataAnnotations;

namespace Car.Domain.Entities
{
    public class CarEntity : Entity
    {
        [Required]
        [MaxLength(4)]
        [MinLength(4)]
        public string Year { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(2)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(2)]
        public string Model { get; set; }
    }
}