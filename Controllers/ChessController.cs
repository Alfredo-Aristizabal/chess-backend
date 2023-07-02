using Microsoft.AspNetCore.Mvc;
using ChessBackend.Entities;


namespace ChessBackend.Controllers
{
    [ApiController]
    public class ChessController : ControllerBase
    {

        private readonly ChessBackendDbContext _context;

        public ChessController(ChessBackendDbContext context) { 
            _context = context;
        }


        [Route("GetUsers")]
        [HttpGet]
        public List<User> GetUsers()
        {

            return _context.Users.ToList();
        }
    }
}
