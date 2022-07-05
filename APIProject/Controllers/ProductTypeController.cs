using APIProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIProject.Repository;
namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : BaseController<ProductType>
    {
        public ProductTypeController(IRepository<ProductType> repository) : base(repository)
        {
        }
    }
}
