using System.ComponentModel.DataAnnotations;

namespace Car.Domain.Entities
{
    /// <summary>
    /// Entidade carro. Tem as propriedades de carro
    /// </summary>
    public sealed class CarEntity : Entity
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