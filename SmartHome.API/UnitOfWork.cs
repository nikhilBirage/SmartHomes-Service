using SmartHome.API.Models;

namespace SmartHome.API
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SmartHomeContext _context;

        public UnitOfWork(SmartHomeContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
