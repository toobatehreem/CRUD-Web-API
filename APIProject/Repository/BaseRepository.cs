using System.Collections.Generic;
using System.Linq;
using APIProject.Data;
using System.IO;
using System;
namespace APIProject.Repository { 
  public abstract class BaseRepository<T> : IRepository<T> where T : class
        {
            protected ApplicationDbContext db;
            public BaseRepository(ApplicationDbContext db)
            {
                this.db = db;
            }
        public int Add(T obj)
        {
            if (obj == null)
            {
                return -1;
            }                
                
        
                try
                {
                    db.Set<T>().Add(obj);
                    db.SaveChanges();
                    return db.SaveChanges();
                }
                catch (IOException)
                {
                    return -1;
                }                
            }

            public int Delete(int id)
            {
            if (id == 0)
            {
                return -1;
            }
            try {
                var itemToDelete = GetById(id);
                db.Set<T>().Remove(itemToDelete);
                db.SaveChanges();
                return db.SaveChanges();
            }
            catch (NullReferenceException)
            {
                return -1;
            }
            }

         
            public ICollection<T> GetAll()
            {
            try
            {
                var data = db.Set<T>().ToList();
                return data;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            }

            public T GetById(int id)
            {
            if (id == 0)
            {
                return null;
            }
            try
            {
                return db.Set<T>().Find(id);
            }
            catch (IndexOutOfRangeException)
            {
               return null; 
            }
            }

            public bool Update(T obj)
            {
            if (obj == null)
            {
                return false;
            }
            try {
                db.Set<T>().Update(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
            }

        }

    }
