using Microsoft.AspNetCore.Mvc;
using ChessBackend.Entities;

namespace ChessBackend.Controllers
{
    [ApiController]
    public class ChessController : Controller
    {

        ChessBackendDbContext _context = new ChessBackendDbContext();

        [Route("GetUsers")]
        [HttpGet]
        public List<User> GetProducts()
        {
            return _context.Users.ToList();
        }
    }
}
