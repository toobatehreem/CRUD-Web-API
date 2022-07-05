using System.Collections.Generic;
using APIProject.Data;
using APIProject.Repository;
using APIProject.Models;
namespace APIProject.Repository
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(ApplicationDbContext db) : base(db)
        {
        }
    }

}
