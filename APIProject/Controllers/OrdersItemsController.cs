using APIProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIProject.Repository;
namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : BaseController<OrderItems>
    {
        public OrderItemsController(IRepository<OrderItems> repository) : base(repository)
        {
        }
    }
}
