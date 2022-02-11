using CDASLiteBusinessLogicLayer.Contracts;
using CDASLiteDataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CDASLiteBusinessLogicLayer.Implementations
{
    public class Repository<T> : IRepositoryBase<T> where T: class, new()
    {
        private readonly MyContext myContext;
        public Repository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public bool Add(T entity)
        {
            try
            {
                bool result = false;
                myContext.Set<T>().Add(entity);
                result = myContext.SaveChanges() > 0 ? true : false;
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                bool result = false;
                myContext.Set<T>().Remove(entity);
                result = myContext.SaveChanges() > 0 ? true : false;
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public T GetById(int id)
        {
            return myContext.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            try
            {
                IQueryable<T> query = myContext.Set<T>();
                if (filter != null)     //alternative to => customerRepo.Queryable().Where()  --from previous .NET project.
                {
                    query = query.Where(filter);
                }

                if (includeProperties != null)
                {
                    //Related tables for the table to be retrieved, will also be obtained.
                    foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(item);
                    }
                }

                if (orderBy != null)
                {
                    return orderBy(query);
                }
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            try
            {
                IQueryable<T> query = myContext.Set<T>();
                if (filter != null)     //alternative to => customerRepo.Queryable().Where()  --from previous .NET project.
                {
                    query = query.Where(filter);
                }

                if (includeProperties != null)
                {
                    //Related tables for the table to be retrieved, will also be obtained.
                    foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(item);
                    }
                }
                return query.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                bool result = false;
                myContext.Set<T>().Update(entity);
                result = myContext.SaveChanges() > 0 ? true : false;
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
