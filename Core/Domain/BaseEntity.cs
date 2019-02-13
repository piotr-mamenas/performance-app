using System.Globalization;

namespace Core.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        
        public bool IsDeleted { get; set; }

        protected BaseEntity()
        {
            IsDeleted = false;
        }

        public static bool operator ==(BaseEntity leftEntity, BaseEntity rightEntity)
        {
            if (ReferenceEquals(leftEntity, null) && ReferenceEquals(rightEntity, null))
            {
                return true;
            }

            if (ReferenceEquals(leftEntity, null) || ReferenceEquals(rightEntity, null))
            {
                return false;
            }

            return leftEntity.Equals(rightEntity);
        }

        public static bool operator !=(BaseEntity leftEntity, BaseEntity rightEntity)
        {
            return !(leftEntity == rightEntity);
        }

        public override bool Equals(object obj)
        {
            var entity = obj as BaseEntity;

            if (ReferenceEquals(entity, null))
            {
                return false;
            }

            if (ReferenceEquals(this, entity))
            {
                return true;
            }

            if (GetType() != entity.GetType())
            {
                return false;
            }

            if (Id == 0 || entity.Id == 0)
            {
                return false;
            }

            return Id == entity.Id;
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        public override string ToString()
        {
            return Id.ToString(CultureInfo.InvariantCulture);
        }
    }
}
