﻿using AssignmentGroup_Repository.Models;
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
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var item in includes)
            {
                if (item.Body is MemberExpression memberExpression)
                {
                    query = query.Include(memberExpression.Member.Name);
                }
            }
            return query.AsNoTracking().ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        public virtual TEntity GetByID(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.FirstOrDefault(e => EF.Property<int>(e, typeof(TEntity).Name + "Id") == id);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
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
