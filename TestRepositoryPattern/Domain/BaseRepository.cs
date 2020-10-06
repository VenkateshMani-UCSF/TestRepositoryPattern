using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepositoryPattern.Domain
{
     public class BaseRepository<TEntity, TContext> : IRepository<TEntity> 
          where TEntity: class
          where TContext : DbContext
     {

          private readonly TContext _context;
          private readonly DbSet<TEntity> _dbSet;

          public BaseRepository(TContext context)
          {
               _context = context;
               _dbSet = context.Set<TEntity>();
          }

          public async Task<TEntity> Add(TEntity entity)
          {
               _dbSet.Add(entity);
               await _context.SaveChangesAsync();
               return entity;
          }

          public async Task<TEntity> Delete(string id)
          {
               var entity = await _dbSet.FindAsync(id);
               if(entity == null)
               {
                    return entity;
               }

               _dbSet.Remove(entity);
               await _context.SaveChangesAsync();
               return entity;
          }

          public async Task<TEntity> Get(string id)
          {
               return await _dbSet.FindAsync(id);
          }

          public async Task<IEnumerable<TEntity>> GetAll()
          {
               return await _dbSet.ToListAsync();
          }

          public async Task<TEntity> Update(TEntity entity)
          {
               _context.Entry(entity).State = EntityState.Modified;
               await _context.SaveChangesAsync();
               return entity;
          }
     }
}
