using AssignmentGroup_Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace AssignmentGroup_Repository.Repo
{
    public class GenericRepo<TEntity> where TEntity : class
    {
        internal CarDbSetContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepo(CarDbSetContext _context)
        {
            context = _context;
            this.dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll( 
            Expression<Func<TEntity,bool>> fillter,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            if(fillter != null)
            {
                query = query.Where(fillter);
            }

            foreach (var item in includes)
            {
                if(item.Body is MemberExpression memberExpression)
                {
                    query = query.Include(memberExpression.Member.Name);
                }
            }
            return query.ToList();
        }

        public virtual void AddRange(IEnumerable<TEntity> entity)
        {
            dbSet.AddRange(entity);
            context.SaveChanges();
        }

        public virtual void RemoveRange()
        {
            dbSet.RemoveRange(dbSet);
            context.SaveChanges();
        }
    }
}
