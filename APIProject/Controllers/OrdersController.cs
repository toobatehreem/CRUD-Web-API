using APIProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIProject.Repository;
namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController<Orders>
    {
        public OrdersController(IRepository<Orders> repository) : base(repository)
        {
        }
    }
}
