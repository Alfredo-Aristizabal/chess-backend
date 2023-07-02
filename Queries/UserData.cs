using ChessBackend.Entities;

namespace ChessBackend.Queries
{
    public class UserData
    {
     
        [UseProjection]
        [HotChocolate.Data.UseFiltering]
        [HotChocolate.Data.UseSorting]
        public  List<User> GetUsers([Service] ChessBackendDbContext context)
        {
            return context.Users.ToList();
        }

    }
}
