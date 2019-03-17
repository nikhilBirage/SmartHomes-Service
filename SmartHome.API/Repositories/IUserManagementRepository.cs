using SmartHome.API.Dtos;
using SmartHome.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.API.Repositories
{
    public interface IUserManagementRepository : IRepository<User>
    {
        IEnumerable<UserMeterDetail> GetUsers();
    }
}
