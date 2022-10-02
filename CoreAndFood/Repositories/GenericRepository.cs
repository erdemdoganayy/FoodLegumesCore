using CoreAndFood.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoreAndFood.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        Context db = new Context();
        public List<T> TList()
        {
            return db.Set<T>().ToList();
        }
        public void TAdd(T parameter)
        {
            db.Set<T>().Add(parameter);
            db.SaveChanges();
        }
        public void TUpdate(T parameter)
        {
            db.Set<T>().Update(parameter);
            db.SaveChanges();
        }
        public void TDelete(T parameter)
        {
            db.Set<T>().Remove(parameter);
            db.SaveChanges();
        }
        public T TGet(int parameter)
        {
           return db.Set<T>().Find(parameter);
        }
        public List<T> TList(string parameter)
        {
            return db.Set<T>().Include(parameter).ToList();
        }
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return db.Set<T>().Where(filter).ToList();
        }
    }
}
