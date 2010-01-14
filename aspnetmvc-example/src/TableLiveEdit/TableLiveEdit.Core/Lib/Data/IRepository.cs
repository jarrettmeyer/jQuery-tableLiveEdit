using System;
using System.Linq;
using System.Linq.Expressions;

namespace TableLiveEdit.Core.Lib.Data
{
    public interface IRepository
    {
        void Commit();
        void Delete<T>(T deleted) where T : class;
        void Insert<T>(T inserted) where T : class;
        IQueryable<T> Find<T>(Expression<Func<T, bool>> expression) where T : class;
        IQueryable<T> FindAll<T>() where T : class;
        T FindSingle<T>(Expression<Func<T, bool>> expression) where T : class;
    }
}
