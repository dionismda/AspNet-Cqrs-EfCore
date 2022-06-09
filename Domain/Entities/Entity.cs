using Domain.Entities.Contracts;

namespace Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>, IEntity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public bool Equals(Entity? other)
        {
            return Id == other.Id;
        }
    }
}
