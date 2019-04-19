using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rex.Temp.BusinessModel;

namespace Rex.Temp.IService
{
    public interface IBaseService
    {
        T Add<T>(T model) where T : class;
        T Update<T>(T model) where T : class;
        T Get<T>(int id) where T : class;
        T Delete<T>(int id) where T : class;

        IList<T> List<T>(Expression<Func<T, bool>> express) where T : class;
        int Count<T>(Expression<Func<T, bool>> express) where T : class;
        PagingModel<T> Page<T>(Expression<Func<T, bool>> expres) where T : class;
    }
}
