using ChessBackend.Entities;

namespace ChessBackend.Queries
{
    public class UserData
    {
        ChessBackendDbContext _context = new ChessBackendDbContext();

        [UseProjection]
        [HotChocolate.Types.UseFiltering]
        [HotChocolate.Types.UseSorting]
        public List<User> GetProducts()
        {
            return _context.Users.ToList();
        }
    }
}
