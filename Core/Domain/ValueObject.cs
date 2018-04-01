namespace Core.Domain
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if (ReferenceEquals(valueObject, null))
            {
                return false;
            }

            return EqualsCore(valueObject);
        }
        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }
        protected abstract int GetHashCodeCore();

        public static bool operator ==(ValueObject<T> leftValueObject, ValueObject<T> rightValueObject)
        {
            if (ReferenceEquals(leftValueObject, null) && ReferenceEquals(rightValueObject, null))
            {
                return true;
            }

            if (ReferenceEquals(leftValueObject, null) || ReferenceEquals(rightValueObject, null))
            {
                return false;
            }

            return leftValueObject.Equals(rightValueObject);
        }

        public static bool operator !=(ValueObject<T> leftValueObject, ValueObject<T> rightValueObject)
        {
            return !(leftValueObject == rightValueObject);
        }
    }
}
