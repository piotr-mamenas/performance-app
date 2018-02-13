namespace Core.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }
        protected abstract int GetHashCodeCore();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftValueObject"></param>
        /// <param name="rightValueObject"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftValueObject"></param>
        /// <param name="rightValueObject"></param>
        /// <returns></returns>
        public static bool operator !=(ValueObject<T> leftValueObject, ValueObject<T> rightValueObject)
        {
            return !(leftValueObject == rightValueObject);
        }
    }
}
