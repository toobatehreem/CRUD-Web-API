using System.Collections.Generic;
namespace APIProject.Repository
{
   
        public interface IRepository<T>
        {
            ICollection<T> GetAll();
            int Add(T entity);
            bool Update(T entity);
            int Delete(int id);
            T GetById(int id);

    }

    
}
