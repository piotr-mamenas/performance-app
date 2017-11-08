using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Core.Interfaces;

namespace Infrastructure.Seed
{
    public abstract class BaseSeeder<T> : ISeedable where T : class, IIdentifiable 
    {
        private readonly IDbSet<T> _set;
        protected IList<T> SeededEntities { get; set; }

        protected BaseSeeder(IDbSet<T> set)
        {
            _set = set;
            SeededEntities = new List<T>();
        }

        public void Seed()
        {
            foreach (var entity in SeededEntities)
            {
                _set.AddOrUpdate(e => e.Id, entity);
            }
        }
    }
}
