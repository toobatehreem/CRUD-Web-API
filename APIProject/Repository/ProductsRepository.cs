using APIProject.Data;
using APIProject.Repository;
using APIProject.Models;


namespace APIProject.Repository
{
    public class ProductsRepository : BaseRepository<Products>
    {
        public ProductsRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
