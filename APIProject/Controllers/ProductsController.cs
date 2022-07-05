using APIProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIProject.Repository;
namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController<Products>
    {
        public ProductsController(IRepository<Products> repository) : base(repository)
        {
        }
    }
}
