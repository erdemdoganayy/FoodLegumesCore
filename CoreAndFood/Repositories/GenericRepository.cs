using CoreAndFood.Data.Models;

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
        public void TGet(int parameter)
        {
            db.Set<T>().Find(parameter);
        }
    }
}
