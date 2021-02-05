using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesonetHomeAssignment.DB.IRepositories;
using TesonetHomeAssignment.DB.Models;

namespace TesonetHomeAssignment.DB.Repositories
{
    public class ServersRepository : Repository<Servers>, IServersRepository
    {
        public ServersRepository(PlaygroundDatabaseEntities context) : base(context)
        {

        }

        public PlaygroundDatabaseEntities dbContext => Context as PlaygroundDatabaseEntities;

    }
}
