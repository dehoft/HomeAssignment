using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesonetHomeAssignment.DB;
using TesonetHomeAssignment.DB.Models;

namespace TesonetHomeAssignment.Helpers
{
    public static class UnitOfWorkHelper
    {
        public static UnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork(new PlaygroundDatabaseEntities());
        }
    }
}
