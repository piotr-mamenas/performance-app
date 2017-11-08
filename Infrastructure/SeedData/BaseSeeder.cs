using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Infrastructure.SeedData
{
    public abstract class BaseSeeder<T> : ISeedable where T : class
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
        }
    }
}
