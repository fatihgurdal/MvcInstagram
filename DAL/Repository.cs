using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Repository<T> where T : class
    {
        InstagramModel _context;
        DbSet<T> _objectSet;

        public Repository()
        {

            _context = new InstagramModel();
            _objectSet = _context.Set<T>();
        }

        public IQueryable<T> AsQueryable()
        {
            return _objectSet;
        }

        public T First(Expression<Func<T, bool>> where)
        {

            return _objectSet.First(where);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where);
        }

        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
            _context.SaveChanges();
        }
        /// <summary>
        /// Ekleme metodudur bu...sadas 
        /// </summary>
        /// <param name="entity">Generic entiti giriniz</param>
        /// <returns>true veya false döner</returns>
        public T Add(T entity)
        {
            try
            {
                _objectSet.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {

                return null;
            }
            
            
        }

        public void Attach(T entity)
        {
            _objectSet.Attach(entity);
            _context.SaveChanges();
        }

        public List<T> Listele()
        {
            List<T> liste = _objectSet.ToList();
            return liste;
        }
       
        public bool UpdateSaveChanges()
        {
            _context.SaveChanges();
            return true;
        }
        // İçerisine aldığı order by sorgusuna göre sıralama yapar
        public List<T> Listele2<F>(Expression<Func<T, F>> where)
        {
            return _objectSet.OrderBy(where).ToList();
        }
        //Aldığı sorguya göre listeleme yapar
        public List<T> SorguyaGoreListele(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }

        
    }
}
