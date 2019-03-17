using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartHome.API.Dtos;
using SmartHome.API.Models;

namespace SmartHome.API.Repositories
{
    public class UserManagementRepository : Repository<User>, IUserManagementRepository
    {
        protected readonly DbSet<MeterUser> Db_MeterUser;

        public UserManagementRepository(SmartHomeContext context) : base(context)
        {
            Db_MeterUser = context.Set<MeterUser>();
        }

        public IEnumerable<UserMeterDetail> GetUsers()
        {
            IEnumerable<UserMeterDetail> data = (from users in DbSet
                                                 join meterUser in Db_MeterUser on users.Id equals meterUser.UserId
                                      select new UserMeterDetail
                                      {
                                          Id = users.Id,
                                          Name = users.Name,
                                          UserName = users.UserName,
                                          Password = users.Password,
                                          MeterNumber = meterUser.MeterNumber
                                      }).ToList();


            return data;
        }
    }
}
