using System;

namespace SmartHome.API
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
