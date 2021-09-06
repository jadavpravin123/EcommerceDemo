using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerce.Data.DataContext
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ECommerceDBContext _context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {
            this._context = new ECommerceDBContext();
            table = _context.Set<T>();
        }
        public GenericRepository(ECommerceDBContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {

            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
