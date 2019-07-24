using System;

namespace Car.Domain.Entities
{
    /// <summary>
    /// Classe abstract responsável por carregar as propriedades base
    /// </summary>
    public abstract class Entity
    {
        public int Id { get; set; }
        public Guid Key { get; set; }
    }
}