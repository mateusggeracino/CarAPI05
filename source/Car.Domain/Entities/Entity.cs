using System;

namespace Car.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public Guid Key { get; set; }
    }
}