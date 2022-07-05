using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIProject.Data;
using APIProject.Models;

namespace APIProject.Repository
{
    public class ProductTypeRepository : BaseRepository<ProductType>
    {
        public ProductTypeRepository(ApplicationDbContext db) : base(db)
        {
        }
    }

}
