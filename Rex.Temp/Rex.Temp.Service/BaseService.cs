using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Rex.Temp.BusinessModel;
using Rex.Temp.IService;
using Rex.Temp.EF.Repository;

namespace Rex.Temp.Service
{
    public class BaseService : IBaseService
    {
        protected RexTempDbContext _dbContext { get; set; }
        protected ILogger _logger { get; set; }

        public BaseService(RexTempDbContext dbContext, ILogger logger)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }

        public T Get<T>(int id) where T : class
        {
            Expression<Func<T, bool>> express = c => Convert.ToInt32(c.GetType().GetProperty("Id").GetValue(c)) == id;
            return _dbContext.Set<T>().FirstOrDefault(express);
        }

        public T Delete<T>(int id) where T : class
        {
            throw new NotImplementedException();
        }

        public IList<T> List<T>(Expression<Func<T, bool>> express) where T : class
        {
            throw new NotImplementedException();
        }

        public int Count<T>(Expression<Func<T, bool>> express) where T : class
        {
            throw new NotImplementedException();
        }

        public PagingModel<T> Page<T>(Expression<Func<T, bool>> expres) where T : class
        {
            throw new NotImplementedException();
        }

        public T Add<T>(T model) where T : class
        {
            var result = _dbContext.Set<T>().Add(model).Entity;
            _dbContext.SaveChanges();
            return result;
        }

        public T Update<T>(T model) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
