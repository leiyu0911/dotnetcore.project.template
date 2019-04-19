using Microsoft.Extensions.Logging;
using System;
using Rex.Temp.IService;
using Rex.Temp.EF.Repository;

namespace Rex.Temp.Service
{
    public class UserService : BaseService, IUserService
    {
        public UserService(RexTempDbContext dbContext, ILogger<UserService> logger)
            : base(dbContext, logger)
        {
        }
    }
}
