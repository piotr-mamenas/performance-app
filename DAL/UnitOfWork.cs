using Core.Interfaces;
using Core.Interfaces.Repositories;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            AssetManagers = new AssetManagerRepository(_context);
        }

        public IAssetManagerRepository AssetManagers { get; private set; }
        public IBankRepository Banks { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
