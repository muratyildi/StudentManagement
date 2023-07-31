using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.EntityFramework;
using Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using X.PagedList;

namespace Data.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        protected DataContext _dataContext;
        internal DbSet<T> _dbSet;
        private readonly IMapper _mapper;

        public EfRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            this._dbSet = dataContext.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            _dataContext.SaveChanges();
            return true;
        }
        public async Task<T> GetById(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dataContext.SaveChanges();
            return true;
        }

        public async Task<IPagedList<T>> GetAll(Expression<Func<T, object>> orderExpression, bool isDesdending,int page, int size)
        {
            var query = GetOrderedQuery(orderExpression, isDesdending);
            return await query.ToPagedListAsync(page, size);
        }

        public async Task<IPagedList<TDest>> GetAll<TDest>(Expression<Func<T, object>> orderExpression, bool isDesdending, int page, int size)
        {
            var query = GetOrderedQuery(orderExpression, isDesdending);
            return await query.ProjectTo<TDest>(_mapper.ConfigurationProvider).ToPagedListAsync(page, size);
        }

        public async Task<IPagedList<T>> GetByFilter(Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderExpression, bool isDesdending, int page, int size)
        {

            var query = GetOrderedQuery(orderExpression, isDesdending);
            return await query.Where(filter).ToPagedListAsync(page, size);
        }

        public async Task<IPagedList<TDest>> GetByFilter<TDest>(Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderExpression, bool isDesdending, int page, int size)
        {
            var query = GetOrderedQuery(orderExpression, isDesdending);
            return await query.Where(filter).ProjectTo<TDest>(_mapper.ConfigurationProvider).ToPagedListAsync(page, size);
        }

        public bool Update(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }

        private IQueryable<T> GetOrderedQuery(Expression<Func<T, object>> orderExpression, bool isDesdending)
        {
            var query = _dbSet.AsQueryable<T>();

            if (isDesdending)
                query = query.OrderByDescending(orderExpression);
            else
                query = query.OrderBy(orderExpression);

            return query;
        }
    }
}
