using System;
using TesonetHomeAssignment.DB.Models;
using System.Data.Entity.Validation;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using TesonetHomeAssignment.DB.IRepositories;
using TesonetHomeAssignment.DB.Repositories;

namespace TesonetHomeAssignment.DB
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlaygroundDatabaseEntities _context;
        
        public IServersRepository Servers { get; private set; }

        public UnitOfWork(PlaygroundDatabaseEntities context)
        {
            _context = context;
            Servers = new ServersRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public (int, Exception) Save()
        {
            int result = -1;
            try
            {
                result = _context.SaveChanges();
                return (result, null);
            }
            catch (DbEntityValidationException)
            {
                return (result, new DbEntityValidationException());
            }
            catch (DbUpdateException)
            {
                return (result, new DbUpdateException());
            }
            catch (InvalidOperationException)
            {
                return (result, new InvalidOperationException());
            }
            catch (EntityException)
            {
                return (result, new EntityException());
            }
            catch (Exception)
            {
                return (result, new Exception());
            }
        }
    }
}
