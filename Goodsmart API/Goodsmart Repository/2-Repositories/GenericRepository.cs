using Goodsmart_Repository._1_IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Goodsmart_Repository._2_Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _Context;


        public GenericRepository(AppDbContext context)
        {
            _Context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await _Context.Set<T>().AddAsync(entity);
            ///*var result =*/ await _Context.SaveChangesAsync();

            if (result != null)
            {
                await _Context.SaveChangesAsync();
                return result.Entity;
            }
            else
                return null;
        }

        //public Task<T> DeleteAsync<O>(O id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<T> GetByIdAsync<O>(O id, params Expression<Func<T, object>>[] includes)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<T> UpdateAsync<O>(O id, T entity, Expression<Func<T, O>> keySelector)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
