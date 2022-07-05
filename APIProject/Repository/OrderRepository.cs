using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APIProject.Data;
using APIProject.Models;

namespace APIProject.Repository
{
    public class OrderRepository : BaseRepository<Orders>
    {
        public OrderRepository(ApplicationDbContext db) : base(db)
        {
        }

    }
}
