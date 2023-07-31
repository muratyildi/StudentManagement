using Entites;
using System.Linq.Expressions;
using X.PagedList;

namespace Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<T>GetById(long id);
        Task<IPagedList<T>> GetAll(Expression<Func<T, object>> orderExpression, bool isDesdending, int page, int size);
        Task<IPagedList<T>> GetByFilter(Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderExpression, bool isDesdending, int page, int size);
        Task<IPagedList<TDest>> GetAll<TDest>(Expression<Func<T, object>> orderExpression, bool isDesdending, int page, int size);
        Task<IPagedList<TDest>> GetByFilter<TDest>(Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderExpression, bool isDesdending, int page, int size);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
