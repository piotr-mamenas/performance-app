using System.Globalization;
using Core.Interfaces;

namespace Core.Domain
{
    /// <summary>
    /// The base entity out of which all domain business entities inherit from
    /// </summary>
    public abstract class BaseEntity : IIdentifiable
    {
        public int Id { get; set; }
        
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftEntity"></param>
        /// <param name="rightEntity"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leftEntity"></param>
        /// <param name="rightEntity"></param>
        /// <returns></returns>
        public static bool operator !=(BaseEntity leftEntity, BaseEntity rightEntity)
        {
            return !(leftEntity == rightEntity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Id.ToString(CultureInfo.InvariantCulture);
        }
    }
}
