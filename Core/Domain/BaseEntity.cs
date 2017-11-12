using System.Globalization;
using Core.Interfaces;

namespace Core.Domain
{
    /// <summary>
    /// The base entity out of which all Domain business entities inherit from
    /// </summary>
    public abstract class BaseEntity : IIdentifiable
    {
        public int Id { get; set; }
        
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Overloading of the equality operator to be able to 
        /// </summary>
        /// <param name="leftEntity"></param>
        /// <param name="rightEntity"></param>
        /// <returns></returns>
        public static bool operator ==(BaseEntity leftEntity, BaseEntity rightEntity)
        {
            return ReferenceEquals(leftEntity, rightEntity) || (object)leftEntity != null && leftEntity.Equals(rightEntity);
        }

        /// <summary>
        /// Overloading of the inequality operator
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

            return entity != null && entity.GetType() == GetType() && (entity.Id == Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
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
