using System;

namespace TesonetHomeAssignment.DB
{
    public interface IUnitOfWork : IDisposable
    {
        (int, Exception) Save();
    }
}
