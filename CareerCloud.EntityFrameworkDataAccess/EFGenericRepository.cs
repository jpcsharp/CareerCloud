using CareerCloud.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository<T> where T:class
    {
            static string connectionstring = "Data Source=LAPTOP-VFAM17U2;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
         CareerCloudContext _db= new CareerCloudContext(connectionstring);
        IQueryable<T> _dbset;

        //public EFGenericRepository(DbContext context)
        //{
        //    context = null;
        //}
        public void Add(params T[] items)
        {
            foreach (var item in items)
            {
                if (item != null)
                {
                    _db.Add(item);
                    _db.SaveChanges();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            _dbset = _db.Set<T>();
            List<T> list=new List<T>();
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                _dbset = _dbset.Include<T, object>(navigationProperty);

            list = _dbset
                .AsNoTracking()
                .ToList<T>();
            return list;
        }

        public IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            _dbset = _db.Set<T>();
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                _dbset = _dbset.Include<T, object>(navigationProperty);

            list = _dbset
                .AsNoTracking()
                .Where(where)
                .ToList<T>();
            return list;
            //throw new NotImplementedException();
        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            _dbset = _db.Set<T>();
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
            { _dbset = _dbset.Include(navigationProperty); }

           item = _dbset.FirstOrDefault(where);
            return item;
           
        }
        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _db.Entry(item).State = EntityState.Deleted;
                _db.SaveChanges();
            }
        }

        public void Update(params T[] items)
        {
            foreach (var item in items)
            {
                _db.Entry(item).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}
