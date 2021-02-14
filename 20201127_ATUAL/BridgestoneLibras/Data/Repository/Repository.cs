using BridgestoneLibras.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BridgestoneLibras.Data.Repository
{
  
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly ApplicationDbContext Context;

        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                return await Context.Set<T>().ToListAsync();
                //return await _context.Set<T>().AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        

        public async Task<T> GetByID(int Id)
        {
            try
            {
                return await Context.Set<T>().FindAsync(Id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> Exists(int Id)
        {
            try
            {
                return await Context.Set<T>().FindAsync(Id) != null;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<List<T>> Get<T2>(Expression<Func<T, bool>> predicate, Expression<Func<T, T2>> order)
        {
            try
            {
                return await Context.Set<T>().AsNoTracking().Where(predicate).OrderBy(order).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public async Task Update(T Item)
        {
            try
            {
                Context.Entry<T>(Item).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<int> Add(T Item)
        {
            try
            {
                Context.Set<T>().Add(Item);
                return await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public int Incluir(T Item)
        {
            try
            {
                Context.Set<T>().Add(Item);
                return Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task AddAll(IEnumerable<T> Items)
        {
            try
            {
                Context.Set<T>().AddRange(Items);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task Delete(int Id)
        {
            try
            {
                var entity = await GetByID(Id);

                Context.Set<T>().Remove(entity);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Atualizar(T Item)
        {
            try
            {
                Context.Entry<T>(Item).State = EntityState.Modified;
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public T GetByID(decimal Id)
        {
            try
            {
                return Context.Set<T>().Find(Id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


    }
}
