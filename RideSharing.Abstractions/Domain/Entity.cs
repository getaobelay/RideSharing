namespace RideSharing.Abstractions.Domain
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; }

        protected Entity() { }
        protected Entity(Guid id)
        {
            Id = id;
        }

        public bool Equals(Entity other)
        {
            if (other is null) return false;

            if (GetType() != other.GetType()) return false;

            if (ReferenceEquals(this, other)) return true;

            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj) => Equals(obj as Entity);

        public static bool operator ==(Entity a, Entity b) => a.Equals(b);

        public static bool operator !=(Entity a, Entity b) => !a.Equals(b);

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}